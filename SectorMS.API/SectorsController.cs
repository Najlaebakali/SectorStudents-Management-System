using Microsoft.AspNetCore.Mvc;
using SectorMS.models;
using SectorMS.Services.Abstractions;

namespace SectorMS.API;

[ApiController]
[Route("api/[controller]")]
public class SectorController : ControllerBase  // Changement le nom du contrôleur en anglais
{
    private readonly ISectorService _sectorService;

    public SectorController(ISectorService sectorService)
    {
        _sectorService = sectorService;
    }
    
    [HttpGet]
    public IActionResult GetAllSectors()
    {
        var sectors = _sectorService.GetAllSectors();  // Appel au service pour récupérer tous les secteurs
        if (sectors == null || sectors.Count == 0)
        {
            return NotFound("No sectors found.");
        }

        return Ok(sectors);  // Retourne les secteurs avec un code HTTP 200
    }
    
    [HttpGet("{id}")]
    public IActionResult GetSector(int id)
    {
        var filiere = _sectorService.GetSectorById(id); 
        if (filiere == null)
        {
            return NotFound(new { Message = "!! Sorry couldn't find the sector!!" });
        }
        return Ok(filiere);
    }

    [HttpPost]
    public IActionResult PostNewSector([FromBody] Sector newSector)
    {
        if (newSector == null)
        {
            return BadRequest(new { Message = "Donnees incorrecte!!" });
        }

        _sectorService.AddSector(newSector);
        return CreatedAtAction(nameof(GetSector), new { id = newSector.Id }, newSector);
    }
}