using SectorMS.Dao.Abstraction;
using SectorMS.Dto;
using SectorMS.models;
using SectorMS.Services.Abstractions;


namespace SectorMS.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IStudentRepository _studentRepository; // Ajout du repository des étudiants

        public SectorService(ISectorRepository sectorRepository, IStudentRepository studentRepository)
        {
            _sectorRepository = sectorRepository;
            _studentRepository = studentRepository;
        }

        // Méthode optimisée pour récupérer les secteurs avec leurs étudiants associés
        public IReadOnlyCollection<SectorDTO> GetAllSectors()
        {
            var sectors = _sectorRepository.GetAllSectors(); // Récupère tous les secteurs
            var allStudents = _studentRepository.GetAllStudents(); // Récupère tous les étudiants une seule fois

            return sectors.Select(sector => new SectorDTO
            {
                Id = sector.Id,
                Name = sector.Name,
                Type = sector.Type,
                
                StudentNames = allStudents
                    .Where(s => s.SectorId == sector.Id)
                    .Select(s => $"{s.FirstName} {s.LastName}")
                    .ToList()
            }).ToList().AsReadOnly();
        }

        
        public Sector GetSectorById(int id)
        {
            return _sectorRepository.GetSectorById(id);  // Pas de DB call dans une boucle
        }
        
       

        public void AddSector(Sector sector)
        {
            _sectorRepository.AddSector(sector);
        }

        public void UpdateSector(Sector sector)
        {
            _sectorRepository.UpdateSector(sector);
        }

        public void DeleteSector(int id)
        {
            _sectorRepository.DeleteSector(id);
        }
    }
}
