using SectorMS.models;
using SectorMS.Dao.Abstraction;


namespace SectorMS.Dao.EF.Sectors
{
    public class SectorsRepository : ISectorRepository
    {
        private readonly List<Sector> _sectors;

        public SectorsRepository()
        {
            // Stocker les donnes en memoire 
            _sectors = new List<Sector>
            {
                new Sector 
                { 
                    Id = 1, 
                    Name = "DevOps", 
                    Type = "Engineering"
                },
                new Sector 
                { 
                    Id = 2, 
                    Name = "x", 
                    Type = "x"
                }
            };
        }

        public IReadOnlyCollection<Sector> GetAllSectors()
        {
            return _sectors.AsReadOnly();
        }

        public Sector GetSectorById(int id)
        {
            return _sectors.FirstOrDefault(s => s.Id == id);
           
        }

        public void AddSector(Sector sector)
        {
            if (sector != null)
            {
                _sectors.Add(sector);
            }
        }

        public void UpdateSector(Sector sector)
        {
            if (sector != null)
            {
                var existingSector = GetSectorById(sector.Id);
                if (existingSector != null)
                {
                    existingSector.Name = sector.Name;
                    existingSector.Type = sector.Type;
                }
            }
        }

        public void DeleteSector(int id)
        {
            var sectorToRemove = GetSectorById(id);
            if (sectorToRemove != null)
            {
                _sectors.Remove(sectorToRemove);
            }
        }
    }
}