using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFLogistcs.Services;

namespace PFLogistcs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) 
        {
          _productService = productService;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAllProducts()
        {
          try
          {
            var _products = await _productService.GetAllProductsAsync();

            if (_products == null) return NoContent();

            return Ok(_products);
          }
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao encontrar Produtos. Erro: {e.Message}");
          }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByProductId(int id)
        {
          try {
            var _product = await _productService.GetProductByIdAsync(id);

            if(_product == null) return NoContent();

            return Ok(_product);            
          } 
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao encontra Produto indicado. Erro: {e.Message}");
          }
        }

        [HttpPost]
        public ActionResult AddProduct()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            return NoContent();
        }
    }
}