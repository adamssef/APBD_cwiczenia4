using AnimalsAppHorizontal.Model;
using AnimalsAppHorizontal.Repositories;

namespace AnimalsAppHorizontal.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;
    
    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    
    public IEnumerable<Animal> GetAnimals(string orderBy="Name")
    {
        //Business logic
        return _animalsRepository.GetAnimals(orderBy);
    }
    
    public int CreateAnimal(Animal animal)
    {
        //Business logic
        return _animalsRepository.CreateAnimal(animal);
    }

    public Animal? GetAnimal(int idAnimal)
    {
        //Business logic
        return _animalsRepository.GetAnimal(idAnimal);
    }

    public int UpdateAnimal(Animal animal)
    {
        //Business logic
        return _animalsRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        //Business logic
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}