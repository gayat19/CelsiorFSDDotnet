using PizzaStoreAPI.Exceptions;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models;

namespace PizzaStoreAPI.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        static List<Customer> customers = new List<Customer>()
        {
            new Customer(){Id=1, Name="John", Email="john@gmail.com", Phone=1234567890},
            new Customer(){Id=2, Name="Jane", Email="jane@gmail.com", Phone=9876543210},
        };
        public async Task<Customer> Add(Customer entity)
        {
            entity.Id = customers.Max(c => c.Id) + 1;
            customers.Add(entity);
            return entity;
        }

        public async Task<Customer> Delete(int key)
        {
            var customer = await Get(key);
            customers.Remove(customer);
            return customer;
        }

        public async Task<Customer> Get(int key)
        {
            var customer = customers.FirstOrDefault(c => c.Id == key);
            if (customer == null)
            {
                throw new NoEntityFoundException("Customer",key);
            }
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            if(customers.Count == 0)
            {
                throw new CollectionEmptyException("Customer");
            }
            return customers;
        }

        public async Task<Customer> Update(Customer entity)
        {
            var customer = await Get(entity.Id);

            if(customer == null)
            {
                throw new NoEntityFoundException("Customer", entity.Id);
            }
            customer.Name = entity.Name;
            customer.Email = entity.Email;
            customer.Phone = entity.Phone;
            return customer;
        }
    }
}
