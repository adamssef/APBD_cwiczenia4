using AnimalsAppHorizontal.Model;

namespace AnimalsAppHorizontal.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy="Name");
    int CreateAnimal(Animal animal);
    Animal GetAnimal(int idStudent);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idStudent);
}