using System.Collections.Generic;
using Cars.Data;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    // api/cars
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        private readonly ICarsRepo _repo;
        // Constructor -> Depency Injection Method
        public CarsController(ICarsRepo repository)
        {
            _repo = repository;
        }



        // GET api/cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAllCars()
        {
            var commandItems = _repo.GetAllCars();

            return Ok(commandItems);


        }

        // GET api/cars/{id}
        [HttpGet("{id}")]
        public ActionResult<Car> GetCarById(int id)
        {
            var commandItems = _repo.GetCarById(id);

            return Ok(commandItems);

        }



    }



}