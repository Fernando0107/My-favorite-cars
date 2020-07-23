using System;
using System.Collections.Generic;
using System.Linq;
using Cars.Models;

namespace Cars.Data
{
    public class SqlCarsRepo : ICarsRepo
    {
        private readonly CarsContext _context;

        public SqlCarsRepo(CarsContext context)
        {
            _context = context;
        }
        // Post a car from CarsContext (DB)
        public void CreateCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            else
            {
                _context.Cars.Add(car);
            }
        }

        public void DeleteCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            else
            {
                _context.Cars.Remove(car);
            }

        }

        // Get all cars from CarsContext (DB)
        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }
        // Get car by Id from CarsContext (DB)
        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }
        // Save Changes from CarsContext
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCar(Car car)
        {
            // Nothing :)
        }
    }

}