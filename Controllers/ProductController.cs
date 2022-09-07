using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFLogistcs.Services;
using PFLogistcs.Models;

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
        public async Task<IActionResult> GetAllProducts()
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
        public async Task<IActionResult> GetByProductId(int id)
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
        public async Task<IActionResult> AddProduct(Product model)
        {
          try
          {
            if (model == null) {
              return this.StatusCode(StatusCodes.Status204NoContent, $"Produto em formato invalido.");
            }

            var _product = await _productService.AddProduct(model);

            return Ok(_product);
          }
          catch (Exception e)
          {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar Produto. Erro: {e.Message}");
          }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product model)
        {
            try
            {
              var _product =  await _productService.UpdateProduct(id, model);
              
              return Ok();
            }
            catch (Exception e)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar Produto selecionado. Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
              var _product = _productService.GetProductByIdAsync(id);

              if (_product == null) 
                return this.StatusCode(StatusCodes.Status204NoContent, $"Produto nao existe ou nao esta cadastrado na base.");

              if (await _productService.DeleteProduct(id)) 
              {
                return Ok(new {message = "Produto deletado com sucesso"});
              } 
              else 
              {
                throw new Exception("Ocorreu um erro nao especificado ao tentar deletar o produto.");
              }
            }
            catch (Exception e)
            {
               return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar Produto. Erro: {e.Message}");
            }
        }
    }
}