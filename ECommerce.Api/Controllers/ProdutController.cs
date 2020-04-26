using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.Api.DTOs;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Specifications;
using ECommerce.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController (IGenericRepository<Product> productsRepo,
                                   IGenericRepository<ProductBrand> productBrandRepo,
                                   IGenericRepository<ProductType> productTypeRepo,
                                   IMapper mapper) {
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts () {
            var spec=new ProductsWithTypesAndBrandsSpecification();
            var products = await _productsRepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(products));
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct (int id) {
            var spec=new ProductsWithTypesAndBrandsSpecification(id);

            var product= await _productsRepo.GetEntityWithSpec (spec);
            return Ok(_mapper.Map<Product,ProductDto>(product));
        }

        [HttpGet ("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands () {
            return Ok (await _productBrandRepo.ListAllAsync ());
        }

        [HttpGet ("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes () {
            return Ok (await _productTypeRepo.ListAllAsync ());
        }
    }
}