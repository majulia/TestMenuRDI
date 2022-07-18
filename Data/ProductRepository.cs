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
        public List<Product> GetProductsActive()
        {
            List<Product> products = new List<Product>();

            using (IDbConnection connection = _dbSession.Connection)
            {
                string sql = @"select 
                                p.prd_id as Id,
                                p.prd_name as name,
                                p.prd_type as type
                                from product p
                                    inner join PRODUCT_STATUS ps on ps.PRD_ID = p.prd_id
                                where 
                                    ps.prd_status = 1
                                    and p.prd_type = 1;
                                
                        ";
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }

        public IEnumerable<Choice> GetChoicesActive()
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sqlChoices = @"select 
                                p.prd_id as Id,
                                p.prd_name as name,
                                p.prd_type as type
                                from product p
                                    inner join PRODUCT_STATUS ps on ps.PRD_ID = p.prd_id
                                where 
                                    ps.prd_status = 1
                                    and p.prd_type = 2;
                        ";


                var choices = connection.Query<Choice>(sqlChoices).ToList();

                foreach (var choice in choices)
                {
                    GetChoicesProducts(connection, choice);
                    if (choice.Products?.Count > 0)
                        yield return choice;
                }
            }
        }

        public IEnumerable<Choice> GetChoicesActive(int valueMealId)
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sqlChoices = @"select 
                                p.prd_id as Id,
                                p.prd_name as name,
                                p.prd_type as type
                                from product p
                                    inner join PRODUCT_STATUS ps on ps.PRD_ID = p.prd_id
                                    inner join PRODUCT_COMPONENTS pc on pc.prd_id = @valueMealId and pc.CHILD_PRD_ID = p.prd_id
                                where 
                                    ps.prd_status = 1
                                    and p.prd_type = 2;
                        ";


                var choices = connection.Query<Choice>(sqlChoices, new { valueMealId }).ToList();

                foreach (var choice in choices)
                {
                    GetChoicesProducts(connection, choice);
                    if (choice.Products?.Count > 0)
                        yield return choice;
                }
            }
        }

        public IEnumerable<ValueMeal> GetValueMealsActive()
        {
            using (IDbConnection connection = _dbSession.Connection)
            {
                string sqlValueMeal = @"select 
                                p.prd_id as Id,
                                p.prd_name as name,
                                p.prd_type as type
                                from product p
                                    inner join PRODUCT_STATUS ps on ps.PRD_ID = p.prd_id
                                where 
                                    ps.prd_status = 1
                                    and p.prd_type = 3;
                        ";


                var valueMeals = connection.Query<ValueMeal>(sqlValueMeal).ToList();

                foreach (var valueMeal in valueMeals)
                {
                    valueMeal.Choices = GetChoicesActive(valueMeal.Id).ToList();
                    if (valueMeal?.Choices?.Count > 0)
                        yield return valueMeal;
                }
            }
        }

        private void GetChoicesProducts(IDbConnection connection, Choice choice)
        {
            string sqlChoicesProduct = @"select 
                                p.prd_id as Id,
                                p.prd_name as name,
                                p.prd_type as type
                                from product p
                                    inner join PRODUCT_STATUS ps on ps.PRD_ID = p.prd_id
                                    inner join PRODUCT_COMPONENTS pc on pc.prd_id = @choiceId and pc.CHILD_PRD_ID = p.prd_id
                                where 
                                    ps.prd_status = 1
                                    and p.prd_type = 1;
                        ";
            choice.Products = connection.Query<Product>(sqlChoicesProduct, new { choiceId = choice.Id }).ToList();
        }
    }
}
