using UnderstandingStructureApp.Interfaces;
using UnderstandingStructureApp.Models;
using UnderstandingStructureApp.Models.ViewModel;
using UnderstandingStructureApp.Repositories;

namespace UnderstandingStructureApp.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository<int, Pizza> _pizzaRepository;
        private readonly IRepository<int, PizzaImages> _imagesRepository;

        public PizzaService(IRepository<int, Pizza> repository,IRepository<int,PizzaImages> imagesRepository)//comming as an injection from the provider
        {
            _pizzaRepository = repository;
            _imagesRepository = imagesRepository;
        }
        public List<PizzaImageViewModel> GetAllPizzas()
        {
            var pizzas = _pizzaRepository.GetAll();
            var pizzaImages = _imagesRepository.GetAll();
            var pizzaImageViewModels = new List<PizzaImageViewModel>();
            foreach (var pizza in pizzas)
            {
                var pizzaImageViewModel = new PizzaImageViewModel()
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Description = pizza.Description,
                    Price = pizza.Price
                };
                foreach (var image in pizzaImages)
                {
                    if (image.Id == pizza.Id)
                    {
                        pizzaImageViewModel.Images.AddRange(image.Images);
                    }
                }
                pizzaImageViewModels.Add(pizzaImageViewModel);
            }
            return pizzaImageViewModels;
        }
    }
}
