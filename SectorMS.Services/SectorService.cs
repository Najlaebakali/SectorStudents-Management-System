using SectorMS.Dao.Abstraction;
using SectorMS.Dto;


namespace SectorMS.Services
{
    public class SectorService
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IStudentRepository _studentRepository;

        public SectorService(ISectorRepository sectorRepository, IStudentRepository studentRepository)
        {
            _sectorRepository = sectorRepository;
            _studentRepository = studentRepository;
        }

        
        public IEnumerable<SectorDTO> GetAllSectors()
        {
            var sectors = _sectorRepository.GetAllSectors();
            return sectors.Select(sector => new SectorDTO
            {
                Id = sector.Id,
                Name = sector.Name,
                Type = sector.Type,
                StudentNames = _studentRepository.GetAllStudents()
                                  .Where(s => s.SectorId == sector.Id)
                                  .Select(s => $"{s.FirstName} {s.LastName}")
                                  .ToList()
            });
        }

       
        public SectorDTO GetSectorById(int id)
        {
            var sector = _sectorRepository.GetSectorById(id);
            if (sector == null) return null;

            return new SectorDTO
            {
                Id = sector.Id,
                Name = sector.Name,
                Type = sector.Type,
                StudentNames = _studentRepository.GetAllStudents()
                                  .Where(s => s.SectorId == sector.Id)
                                  .Select(s => $"{s.FirstName} {s.LastName}")
                                  .ToList()
            };
        }

        
        public void AddSector(SectorDTO sectorDto)
        {
            var sector = new models.Sector
            {
                Id = sectorDto.Id,
                Name = sectorDto.Name,
                Type = sectorDto.Type
            };
            _sectorRepository.AddSector(sector);
        }

       
        public void UpdateSector(int id, SectorDTO sectorDto)
        {
            var existingSector = _sectorRepository.GetSectorById(id);
            if (existingSector != null)
            {
                existingSector.Name = sectorDto.Name;
                existingSector.Type = sectorDto.Type;
                _sectorRepository.UpdateSector(existingSector);
            }
        }

        
        public void DeleteSector(int id)
        {
            _sectorRepository.DeleteSector(id);
        }
    }
}
