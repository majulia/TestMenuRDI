using TestMenu.Models;

namespace TestMenu.Data.Interfaces
{
    public interface IStatusRepository
    {
        List<Product> GetAllProducts();
        List<ProductStatus> GetProductStatus();
        bool EnableProduct(int id);
        bool DisableProduct(int id);
    }
}
