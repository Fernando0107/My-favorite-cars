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

        public IEnumerable<Car> GetAllCars()
        {
            return _context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(x => x.Id == id);
        }
    }

}