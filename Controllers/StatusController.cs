using Microsoft.AspNetCore.Mvc;
using TestMenu.Data.Interfaces;
using TestMenu.Models;

namespace TestMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _repo;
        public StatusController(IStatusRepository repo)
        {
            _repo = repo;

        }

        [HttpGet("GetAllProducts")]
        public List<Product> GetProducts()
        {
            try
            {
                return _repo.GetAllProducts();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetProductStatus")]
        public List<ProductStatus> GetProductStatus()
        {
            try
            {
                return _repo.GetProductStatus();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("EnableProduct")]
        public void EnableProduct(int id)
        {
            try
            {
                _repo.EnableProduct(id);               
               
            }
            catch (Exception)
            {
                throw;

            }
        }

        [HttpPut("DisableProduct")]
        public void DisableProduct(int id)
        {
            try
            {
                _repo.DisableProduct(id);
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
