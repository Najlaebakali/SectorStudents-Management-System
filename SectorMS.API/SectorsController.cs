using Microsoft.AspNetCore.Mvc;
using SectorMS.models;
using SectorMS.Dao.Abstraction;

namespace SectorMS.API;

[ApiController]
[Route("api/[controller]")]
public class SectorController : ControllerBase  // Changement le nom du contrôleur en anglais
{
    private readonly ISectorRepository _sectorRepository;

    public SectorController(ISectorRepository sectorRepository)
    {
        _sectorRepository = sectorRepository;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetFiliere(int id)
    {
        var filiere = _sectorRepository.GetSectorById(id); 
        if (filiere == null)
        {
            return NotFound(new { Message = "!! Sorry couldn't find the sector!!" });
        }
        return Ok(filiere);
    }

    [HttpPost]
    public IActionResult PostNewFiliere([FromBody] Sector newFiliere)
    {
        if (newFiliere == null)
        {
            return BadRequest(new { Message = "Donnees incorrecte!!" });
        }

        _sectorRepository.AddSector(newFiliere);
        return CreatedAtAction(nameof(GetFiliere), new { id = newFiliere.Id }, newFiliere);
    }
}