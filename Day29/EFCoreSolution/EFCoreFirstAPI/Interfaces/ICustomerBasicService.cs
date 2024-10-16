
using EFCoreFirstAPI.Models.DTOs;

namespace EFCoreFirstAPI.Interfaces
{
    public interface ICustomerBasicService
    {
        Task<int> CreateCustomer(CustomerDTO customer);
    }
}
