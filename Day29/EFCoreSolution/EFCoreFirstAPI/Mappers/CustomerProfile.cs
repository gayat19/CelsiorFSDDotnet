using AutoMapper;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;

namespace EFCoreFirstAPI.Mappers
{
    public class CustomerProfile :Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();
        }
    }
}
