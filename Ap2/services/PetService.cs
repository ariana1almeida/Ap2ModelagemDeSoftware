using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class PetService
{
    private readonly IRepository<Pet> _petRepository;

    public PetService(IRepository<Pet> petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task<IEnumerable<Pet>> GetAllPetsAsync()
    {
        return await _petRepository.GetAllAsync();
    }

    public async Task<Pet> GetPetByIdAsync(int id)
    {
        return await _petRepository.GetByIdAsync(id);
    }

    public async Task AddPetAsync(Pet pet)
    {
        await _petRepository.AddAsync(pet);
    }

    public async Task UpdatePetAsync(Pet pet)
    {
        await _petRepository.UpdateAsync(pet);
    }

    public async Task DeletePetAsync(int id)
    {
        await _petRepository.DeleteAsync(id);
    }
}