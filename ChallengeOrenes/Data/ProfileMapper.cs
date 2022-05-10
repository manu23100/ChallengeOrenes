using AutoMapper;
using ChallengeOrenes;
using ChallengeOrenes.Entities;
using ChallengeOrenes.DTO;

namespace ChallengeOrenes.Data
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Vehicle, VehicleDTO>();   
            CreateMap<VehicleDTO, Vehicle>();   

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO, Location>();

            CreateMap<VehicleChildDTO, Vehicle>();
            CreateMap<Vehicle, VehicleChildDTO>();

            CreateMap<User, UserChildDTO>();
            CreateMap<UserChildDTO, User>();

            CreateMap<Location, LocationDTO>();
            CreateMap<LocationDTO,Location>();

        }
    }
}