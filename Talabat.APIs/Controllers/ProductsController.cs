using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;

namespace Talabat.APIs.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;

        public ProductsController(IGenericRepository<Product> productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Products = await _productsRepo.GetAllAysnc();

            return Ok(Products);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            var product  = await _productsRepo.GetAysnc(id);

            if(product is null)
                return NotFound(); //404

            return Ok(product); //200
        } 
    }
}
