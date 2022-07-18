using Dapper;
using System.Data;
using TestMenu.Models;
using TestMenu.Data.Interfaces;

namespace TestMenu.Data
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DbSession _dbSession;
        public StatusRepository(DbSession dbSession)
        {
            _dbSession = dbSession;
        }


        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = "SELECT prd_id as Id, prd_name as Name, prd_type as Type FROM product";

                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }

        public List<ProductStatus> GetProductStatus()
        {
            List<ProductStatus> status = new List<ProductStatus>();
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = "SELECT prd_id as Id, prd_status as Status FROM product_status";

                status = connection.Query<ProductStatus>(sql).ToList();
            }
            return status;
        }

        public bool EnableProduct(int id)
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = @"UPDATE product_status 
                                set 
                                prd_status = 1
                                FROM product_status ps inner join product p on 
                                ps.PRD_ID = p.prd_id
                                WHERE
                                p.prd_id = @id and ps.prd_status = 0;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                int result = 0;
                result = connection.Execute(sql, parameters);
                return (result != 0 ? true : false);
            }
        }

        public bool DisableProduct(int id)
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = @"UPDATE product_status 
                                set 
                                prd_status = 0
                                FROM product_status ps inner join product p on 
                                ps.PRD_ID = p.prd_id
                                WHERE
                                p.prd_id = @id and ps.prd_status = 1;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);

                int result = 0;
                result = connection.Execute(sql, parameters);
                return (result != 0 ? true : false);
            }
        }

    }
}
