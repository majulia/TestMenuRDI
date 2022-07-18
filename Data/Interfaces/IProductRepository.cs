using TestMenu.Models;

namespace TestMenu.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProductsActive();
        IEnumerable<Choice> GetChoicesActive();
        IEnumerable<Choice> GetChoicesActive(int valueMealId);
        IEnumerable<ValueMeal> GetValueMealsActive();
    }
}
