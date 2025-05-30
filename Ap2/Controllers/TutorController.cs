using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TutorController : ControllerBase
{
    private readonly TutorService _tutorService;

    public TutorController(TutorService tutorService)
    {
        _tutorService = tutorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tutor>>> GetAllTutors()
    {
        var tutors = await _tutorService.GetAllTutorsAsync();
        return Ok(tutors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tutor>> GetTutorById(int id)
    {
        var tutor = await _tutorService.GetTutorByIdAsync(id);
        if (tutor == null)
        {
            return NotFound();
        }
        return Ok(tutor);
    }

    [HttpPost]
    public async Task<ActionResult<Tutor>> AddTutor([FromBody] Tutor tutor)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _tutorService.AddTutorAsync(tutor);
        return CreatedAtAction(nameof(GetTutorById), new { id = tutor.id }, tutor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTutor(int id, [FromBody] Tutor tutor)
    {
        if (id != tutor.id)
        {
            return BadRequest();
        }

        await _tutorService.UpdateTutorAsync(tutor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTutor(int id)
    {
        await _tutorService.DeleteTutorAsync(id);
        return NoContent();
    }
}