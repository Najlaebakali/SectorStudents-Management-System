using SectorMS.models;

namespace SectorMS.Services.Abstractions;

public interface ISectorService
{
    IReadOnlyCollection<Sector> GetAllSectors();  
    Sector GetSectorById(int id);
    void AddSector(Sector sector);
    void UpdateSector(Sector sector);
    void DeleteSector(int id);
}