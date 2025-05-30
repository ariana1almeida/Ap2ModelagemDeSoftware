using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    private readonly PetService _petService;

    public PetController(PetService petService)
    {
        _petService = petService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pet>>> GetAllPets()
    {
        var pets = await _petService.GetAllPetsAsync();
        return Ok(pets);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPetById(int id)
    {
        var pet = await _petService.GetPetByIdAsync(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPost]
    public async Task<ActionResult<Pet>> AddPet([FromBody] Pet pet)
    {
        // Certifique-se de que o TutorId foi fornecido
        if (pet.TutorId <= 0)
        {
            return BadRequest("TutorId is required.");
        }

        await _petService.AddPetAsync(pet);

        // Carregar o Tutor associado
        var createdPet = await _petService.GetPetByIdAsync(pet.PetId);

        return CreatedAtAction(nameof(GetPetById), new { id = createdPet.PetId }, createdPet);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet pet)
    {
        if (id != pet.PetId)
        {
            return BadRequest();
        }

        await _petService.UpdatePetAsync(pet);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        await _petService.DeletePetAsync(id);
        return NoContent();
    }
}