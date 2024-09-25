using PizzaStoreAPI.Models.DTOs;

namespace PizzaStoreAPI.Interfaces
{
    public interface ICartService
    {
        public Task<PizzaCartDTO> AddPizzaToCart(PizzaCartDTO pizzaCartDTO, int customerId);
        public Task<CartDTO> GetCart(int customerId);
        public Task<CartDTO> UpdateCart(int cartNumber, PizzaCartDTO pizzaCartDTO);

    }
}
