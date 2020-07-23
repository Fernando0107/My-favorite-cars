using System.Collections.Generic;
using AutoMapper;
using Cars.Data;
using Cars.Dtos;
using Cars.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    // api/cars
    [Route("api/[controller]")]
    [ApiController]

    public class CarsController : ControllerBase
    {
        private readonly ICarsRepo _repo;
        private readonly IMapper _mapper;

        // Constructor -> Depency Injection Method
        public CarsController(ICarsRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        // GET api/cars
        [HttpGet]
        public ActionResult<IEnumerable<CarReadDto>> GetAllCars()
        {
            var commandItems = _repo.GetAllCars();

            return Ok(_mapper.Map<IEnumerable<CarReadDto>>(commandItems));
        }

        // GET api/cars/{id}
        [HttpGet("{id}", Name = "GetCarById")]
        public ActionResult<CarReadDto> GetCarById(int id)
        {
            var commandItems = _repo.GetCarById(id);

            if (commandItems != null)
            {
                return Ok(_mapper.Map<CarReadDto>(commandItems));
            }
            else
            {
                return NotFound();
            }

        }

        // POST api/cars/
        [HttpPost]
        public ActionResult<CarReadDto> CreateCar(CarCreateDto carCreateDto)
        {
            var carModel = _mapper.Map<Car>(carCreateDto);

            _repo.CreateCar(carModel);

            _repo.SaveChanges();

            var carReadDto = _mapper.Map<CarReadDto>(carModel);

            return CreatedAtRoute(nameof(GetCarById), new { Id = carReadDto.Id }, carReadDto);

        }

        // PUT api/cars/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCar(int id, CarUpdateDto carUpdateDto)
        {
            var carModelFromRepo = _repo.GetCarById(id);

            if (carModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(carUpdateDto, carModelFromRepo);

                _repo.UpdateCar(carModelFromRepo);

                _repo.SaveChanges();

                return NoContent();

            }
        }

        // Patch api/cars/{id}
        [HttpPatch("{id}")]

        public ActionResult PartialCarUpdate(int id, JsonPatchDocument<CarUpdateDto> patchDoc)
        {
            var carModelFromRepo = _repo.GetCarById(id);

            if (carModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                var carToPatch = _mapper.Map<CarUpdateDto>(carModelFromRepo);
                patchDoc.ApplyTo(carToPatch, ModelState);

                if (!TryValidateModel(carToPatch))
                {
                    return ValidationProblem(ModelState);
                }
                else
                {
                    _mapper.Map(carToPatch, carModelFromRepo);
                    _repo.UpdateCar(carModelFromRepo);

                    _repo.SaveChanges();

                    return NoContent();
                }


            }

        }

    }

}