using System.Collections.Generic;
using Cars.Models;

namespace Cars.Data
{
    // List of definitions
    public interface ICarsRepo
    {
        // List of the methods signatures that we are going to provide 
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);

    }

}