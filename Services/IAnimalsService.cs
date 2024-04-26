using AnimalsAppHorizontal.Model;

namespace AnimalsAppHorizontal.Services;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals();
    int CreateAnimal(Animal animal);
    Animal? GetAnimal(int idStudent);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idStudent);
}