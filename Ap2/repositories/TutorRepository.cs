using Microsoft.EntityFrameworkCore;

public class TutorRepository : Repository<Tutor>
{
    public TutorRepository(PetshopContext context) : base(context) { }
}