using EFCoreFirstAPI.Models;
using EFCoreFirstAPI.Models.DTOs;

namespace EFCoreFirstAPI.Interfaces
{
    public interface IProductService
    {
        public Task<bool> AddNewProduct(ProductDTO product);

        public Task<ICollection<Product>> GetAllProducts();
    }
}
