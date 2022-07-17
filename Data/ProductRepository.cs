using Dapper;
using System.Data;
using TestMenu.Data.Interfaces;
using TestMenu.Models;

namespace TestMenu.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSession _dbSession;
        public ProductRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }
        public List<Product> GetProduct()
        {
            List<Product> products = new List<Product>();

            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = "select prd_id, prd_name, prd_type from product";
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }
    }
}
