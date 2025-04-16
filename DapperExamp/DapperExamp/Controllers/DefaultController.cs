using DapperExamp.Dtos;
using DapperExamp.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperExamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values=await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto model)
        {
            await _productService.CreateProductAsync(model);
            return Ok("Ürün Başarılı Şekilde Kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün Başarılı Şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto model)
        {
            await _productService.UpdateProductAsync(model);
            return Ok("Ürün Başarılı Şekilde Güncellendi.");
        }
    }
}
