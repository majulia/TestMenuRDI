using TestMenu.Models;

namespace TestMenu.Data.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProduct();
    }
}
