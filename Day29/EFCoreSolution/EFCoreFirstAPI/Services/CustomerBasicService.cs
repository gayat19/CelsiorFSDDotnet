using AutoMapper;
using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;

namespace EFCoreFirstAPI.Services
{
    public class CustomerBasicService : ICustomerBasicService
    {
        private readonly IRepository<int, Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerBasicService(IRepository<int,Customer> customerRepository,IMapper mapper) 
        { 
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> CreateCustomer(CustomerDTO customer)
        {
            //Customer newCustomer = MapCustomerDTOToCustomer(customer);
            Customer newCustomer = _mapper.Map<Customer>(customer);

            newCustomer.Age = CalculateAgeFromDateTime(customer.DateOfBirth);
            var addedCustomer = await _customerRepository.Add(newCustomer);
            return addedCustomer.Id;
        }

        //private Customer MapCustomerDTOToCustomer(CustomerDTO customer)
        //{
        //    return new Customer
        //    {
        //        Name = customer.Name,
        //        Email = customer.Email,
        //        Phone = customer.Phone,
        //        DateOfBirth = customer.DateOfBirth
        //    };
        //}

        int CalculateAgeFromDateTime(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
