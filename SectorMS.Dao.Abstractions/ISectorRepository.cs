using SectorMS.models;

namespace SectorMS.Dao.Abstraction;

public interface ISectorRepository
{
    IReadOnlyCollection<Sector> GetAllSectors();  
    Sector GetSectorById(int id);
    void AddSector(Sector sector);
    void UpdateSector(Sector sector);
    void DeleteSector(int id);
    
}