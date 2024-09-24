using UnderstandingStructureApp.Models;
using UnderstandingStructureApp.Models.ViewModel;

namespace UnderstandingStructureApp.Interfaces
{
    public interface IPizzaService
    {
        List<PizzaImageViewModel> GetAllPizzas();
    }
}
