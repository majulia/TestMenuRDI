using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestMenu.Data.Interfaces;
using TestMenu.Models;

namespace TestMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetProducts")]
        public List<Product> Get()
        {
            try
            {
                return _repo.GetProduct();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
