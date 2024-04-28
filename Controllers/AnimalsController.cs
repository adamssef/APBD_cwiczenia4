using AnimalsAppHorizontal.Model;
using AnimalsAppHorizontal.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsAppHorizontal.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;
    
    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }
    
    /// <summary>
    /// Endpoints used to return list of students.
    /// </summary>
    /// <returns>List of students</returns>
    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "Name")
    {
        var requestQuery = this.Request.Query;


        orderBy = requestQuery.ContainsKey("orderBy") ? requestQuery["orderBy"].ToString() : "Name";



        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    /// <summary>
    /// Endpoint used to return a single animal.
    /// </summary>
    /// <param name="id">Id of a animal</param>
    /// <returns>Animal</returns>
    [HttpGet("{id:int}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = _animalsService.GetAnimal(id);

        if (animal==null)
        {
            return NotFound("Animal not found");
        }
        
        return Ok(animal);
    }
    
    /// <summary>
    /// Endpoint used to create an animal.
    /// </summary>
    /// <param name="animal">New animal data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    /// <summary>
    /// Endpoint used to update a animal.
    /// </summary>
    /// <param name="id">Id of a animal</param>
    /// <param name="animal">204 No Content</param>
    /// <returns></returns>
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var affectedCount = _animalsService.UpdateAnimal(animal);
        return NoContent();
    }
    
    /// <summary>
    /// Endpoint used to delete a student.
    /// </summary>
    /// <param name="id">Id of a animal</param>
    /// <returns>204 No Content</returns>
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalsService.DeleteAnimal(id);
        return NoContent();
    }
}