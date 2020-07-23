using AutoMapper;
using Cars.Models;
using Cars.Dtos;

namespace Cars.Profiles
{
    public class CarsProfile : Profile
    {
        public CarsProfile()
        {
            // Source -> destination(Target)

            // Get
            CreateMap<Car, CarReadDto>();
            // Post
            CreateMap<CarCreateDto, Car>();
            // Update
            CreateMap<CarUpdateDto, Car>();
        }

    }


}