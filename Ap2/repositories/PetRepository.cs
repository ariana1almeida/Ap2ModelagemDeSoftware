using Microsoft.EntityFrameworkCore;

public class PetRepository : Repository<Pet>
{
    public PetRepository(PetshopContext context) : base(context) { }
}