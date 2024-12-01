using SectorMS.Dao.Abstraction;
using SectorMS.models;
using SectorMS.Services.Abstractions;

namespace SectorMS.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;

        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public IReadOnlyCollection<Sector> GetAllSectors()
        {
            return _sectorRepository.GetAllSectors();  // Pas de DB call dans une boucle
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