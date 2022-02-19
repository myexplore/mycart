using AutoMapper;
using Catalog.Api.Dtos;
using Catalog.Api.Entities;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controller
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController:ControllerBase
    {

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> GetProducts()
        //{
        //    var product = new Product[] { };
        //    return Ok(product);
        //}
        IMapper mapper = null;
        ICatalogRepository repository = null;

        public CatalogController(IMapper mapper,ICatalogRepository repository)
        {
             this.mapper = mapper;
            this.repository = repository;
        }
        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        //{
        //    var products = await repository.GetAllAsync();
        //    return Ok(products);
        //}
        [Route("products")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await repository.GetAllAsync();

            return Ok(products);
        }
        [HttpGet(Name = "product/{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await repository.GetByIdAsync(id);

            if (product == null)
            {
                // _logger.LogError($"Product with id: {id}, not found.");
                return NotFound();
            }

            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {

            var product = mapper.Map<ProductDto, Product>(productDto);
            await repository.AddAsync(product);
            return CreatedAtRoute("product/{id}", new { Id = product.Id });
        }
    }



}
