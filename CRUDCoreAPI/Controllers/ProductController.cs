using CRUDCoreAPI.DataAccessLayer;
using CRUDCoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUDCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        
        public ProductController(IProduct product)
        {
            _product = product;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _product.GetProducts();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _product.GetProductById(id);
            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> CreateProduct(Product pro)
        
        {
             await _product.AddProduct(pro);
            //if (result == null)
            //{
            //    return NotFound();
            //}
            return Ok("product Created Succefully");
            //return CreatedAtAction(nameof(CreateProduct), result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> EditProduct(Product pro,  int id)
        {
            await _product.UpdateProduct(id, pro);
            return Ok("Product Updated");
        }



        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _product.DeleteProduct(id);
            return Ok("Product Deleted");
        }
    }
}
