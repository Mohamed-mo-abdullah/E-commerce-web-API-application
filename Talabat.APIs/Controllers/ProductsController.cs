﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.Dtos;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repositories.Contract;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.product_Specs;

namespace Talabat.APIs.Controllers
{

    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo ,IMapper mapper)
        {
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
        {
            var spec = new BaseSpecification<Product>();

            var Products = await _productsRepo.GetAllWithSpecAysnc(spec);

            return Ok(_mapper.Map<IEnumerable<Product>,IEnumerable<ProductToReturnDto>>(Products));
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);
            

            var product  = await _productsRepo.GetWithSpecAysnc(spec);

            if(product is null)
                return NotFound(new ApiResponse(404)); //404

            return Ok(_mapper.Map<Product,ProductToReturnDto>(product)); //200
        } 
    }
}
