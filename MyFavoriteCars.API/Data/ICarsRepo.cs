using System.Collections.Generic;
using Cars.Models;

namespace Cars.Data
{
    // List of definitions
    public interface ICarsRepo
    {
        // List of the methods signatures that we are going to provide 

        // Save Changes in the database
        bool SaveChanges();
        // GET
        IEnumerable<Car> GetAllCars();
        // GET by Id
        Car GetCarById(int id);
        // POST
        void CreateCar(Car car);
        // PUT
        void UpdateCar(Car car);

    }

}