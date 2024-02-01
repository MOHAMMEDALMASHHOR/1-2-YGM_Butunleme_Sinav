using Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace CarsApp.Controllers;
[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
    private readonly RepositoryContext _context;

    public CarsController(RepositoryContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetAllCar()
    {
        var cars = _context.Cars.ToList();
        return Ok(cars);
    }
    [HttpGet("{pageNumber:int}")]
    public IActionResult GetCarByPage(int pageNumber)
    {
        var cars = _context.Cars.Skip((pageNumber - 1) * 5).Take(5).ToList();
        return Ok(cars);
    }
    [HttpPost]
    public IActionResult AddCars(Car[] cars)
    {
        foreach (var item in cars)
        {
            _context.Cars.Add(item);
        }
        _context.SaveChanges();
        return Ok(cars);
    }
    [HttpPut("{id:int}")]
    public IActionResult UpdateOneCar([FromRoute(Name ="id")]int id,[FromBody] Car cars){
        var car = _context.Cars.Find(id);
        if(car == null){
            return NotFound();
        }
        car.Brand = cars.Brand;;
        car.Model = cars.Model;
        car.Year = cars.Year;
        car.Price = cars.Price;
        _context.SaveChanges();
        return Ok(car);
    }
    

}