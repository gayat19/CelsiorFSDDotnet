using PizzaStoreAPI.Exceptions;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;
using PizzaStoreAPI.Models.DTOs;
using PizzaStoreAPI.Repositories;

namespace PizzaStoreAPI.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<int, Customer> _customerRepository;
        private readonly IRepository<int, Pizza> _pizzaRepository;
        private readonly IRepository<int, Cart> _cartRepository;

        public CartService(
            IRepository<int,Customer> customerRepository,
            IRepository<int, Pizza> pizzaRepository,
            IRepository<int, Cart> cartRepository
            )
        {
            _customerRepository = customerRepository;
            _pizzaRepository = pizzaRepository;
            _cartRepository = cartRepository;

        }
        public async Task<PizzaCartDTO> AddPizzaToCart(PizzaCartDTO pizzaCartDTO, int customerId)
        {
            if (!(await DoesCustomerHaveCart(customerId)))
            {
                var cart = await CareateNewCart(customerId, pizzaCartDTO.PizzaId, pizzaCartDTO.Quantity);
                var mycart = await _cartRepository.Add(cart);
                return pizzaCartDTO;
            }
            var custCart = await GetCustomerCart(customerId);
            if (await DoesCartContainPizza(custCart.CartNumber, pizzaCartDTO.PizzaId))
            {
                var pizza =  custCart.Pizzas.FirstOrDefault(p => p.Id == pizzaCartDTO.PizzaId);
                pizza.Quantity += pizzaCartDTO.Quantity;
            }
            custCart.Pizzas.Add(await CreatePizza(pizzaCartDTO));
            await _cartRepository.Update(custCart);
            return pizzaCartDTO;
        }
        //create a new pizza object with the pizzaCartDTO
        async Task<Pizza> CreatePizza(PizzaCartDTO pizzaCartDTO)
        {
            Pizza pizza = new Pizza()
            {
                Id = pizzaCartDTO.PizzaId,
                Quantity = pizzaCartDTO.Quantity,
                Name = pizzaCartDTO.PizzaName,
                Price = pizzaCartDTO.Price
            };
            return pizza;
        }

        //check if teh cart contains pizza with same id
        async Task<bool> DoesCartContainPizza(int cartId, int pizzaId)
        {
            var cart = await _cartRepository.Get(cartId);
            return cart.Pizzas.Any(p => p.Id == pizzaId);
        }


        //get cart with the customer id
        async Task<Cart> GetCustomerCart(int customerId)
        {
            var carts = await _cartRepository.GetAll();
            var cart = carts.FirstOrDefault(c => c.CustomerId == customerId);
            return cart;
        }
        //checking if customer has a cart already
        async Task<bool> DoesCustomerHaveCart(int customerId)
        {
            try
            {
                var customer = await _customerRepository.Get(customerId);
                var carts = await _cartRepository.GetAll();
                var custCart = carts.FirstOrDefault(c => c.CustomerId == customerId);
                return custCart != null;
            }
            catch(CollectionEmptyException ex)
            {
                return false;
            }
        }
        //creating a new cart object for the customer add teh pizza to the cart
        async Task<Cart> CareateNewCart(int customerId,int pizzaId, int qty)
        {
            Cart cart = new Cart()
            {
                CustomerId = customerId,
            };
            Pizza pizza = await _pizzaRepository.Get(pizzaId);
            pizza.Quantity = qty;
            cart.Pizzas.Add(pizza);
            return cart;

        }

        public async Task<CartDTO> GetCart(int customerId)
        {
           var cart = await GetCustomerCart(customerId);
            var pizzaDtoObjects = await MapPizzaToPizzaDTO(cart.Pizzas);
            return new CartDTO()
            {
                CartNumber = cart.CartNumber,               
                Pizzas = pizzaDtoObjects
            };
        }

         async Task<List<PizzaCartDTO>> MapPizzaToPizzaDTO(List<Pizza> pizzas)
        {
            List<PizzaCartDTO> pizzaCartDTOs = new List<PizzaCartDTO>();
            foreach (var pizza in pizzas)
            {
                PizzaCartDTO pizzaCartDTO = new PizzaCartDTO()
                {
                    PizzaId = pizza.Id,
                    PizzaName = pizza.Name,
                    Price = pizza.Price,
                    Quantity = pizza.Quantity
                };
                pizzaCartDTOs.Add(pizzaCartDTO);
            }
            return pizzaCartDTOs;
        }

        public Task<CartDTO> UpdateCart(int cartNumber, PizzaCartDTO pizzaCartDTO)
        {
            throw new NotImplementedException();
        }
    }
}
