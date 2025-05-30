using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TutorService
{
    private readonly IRepository<Tutor> _tutorRepository;

    public TutorService(IRepository<Tutor> tutorRepository)
    {
        _tutorRepository = tutorRepository;
    }

    public async Task<IEnumerable<Tutor>> GetAllTutorsAsync()
    {
        return await _tutorRepository
            .Query()
            .Include(t => t.Pets)
            .ToListAsync();
    }

    public async Task<Tutor> GetTutorByIdAsync(int id)
    {
        return await _tutorRepository
            .Query()
            .Include(t => t.Pets)
            .FirstOrDefaultAsync(t => t.id == id);
    }

    public async Task AddTutorAsync(Tutor tutor)
    {
        tutor.Pets = null;
        await _tutorRepository.AddAsync(tutor);
    }

    public async Task UpdateTutorAsync(Tutor tutor)
    {
        await _tutorRepository.UpdateAsync(tutor);
    }

    public async Task DeleteTutorAsync(int id)
    {
        await _tutorRepository.DeleteAsync(id);
    }
}