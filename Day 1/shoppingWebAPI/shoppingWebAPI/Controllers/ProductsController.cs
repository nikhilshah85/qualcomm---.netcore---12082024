using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Products pObj = new Products(); //very bad code, use DI instead

        Products _pObj;

        public ProductsController(Products _pObjREF)
        {
            _pObj = _pObjREF;
        }


        [HttpGet]
        [Route("/products/list")]
        public IActionResult ShowAllProducts()
        {
           
            return Ok(_pObj.GetAllProducts());
        }

        [HttpGet]
        [Route("/products/{id}")]
        public IActionResult ShowProduct(int id)
        {
            return Ok(_pObj.GetProductById(id));
        }


        [HttpGet]
        [Route("/products/total")]
        public IActionResult TotalProducts()
        {
            return Ok(_pObj.GetTotalProducts());
        }

        [HttpGet]
        [Route("/products/avability/{yesno}")]
        public IActionResult GetByAvability(bool yesno)
        {
            return Ok(_pObj.GetByAvability(yesno));
        }


        [HttpPost]
        [Route("/products/add/{newProduct}")]
        public IActionResult AddProduct([FromBody]Products newProduct)
        {
            _pObj.AddProduct(newProduct);
            return Created("", "Product Added Successfully");
        }

        [HttpPut]
        [Route("/products/edit/{prod}")]
        public IActionResult EditProduct([FromBody] Products prod)
        {
            try
            {
                _pObj.UpdateProduct(prod);
                return Accepted("Product Updated Successfully");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/products/delete/{prod}")]
        public IActionResult DeleteProduct(int id) 
        {
            try
            {
                _pObj.DeleteProduct(id);
                return Accepted("Product Deleted Successfully");
            }
            catch (Exception es)
            {

                return BadRequest(es.Message);
            }
        }
    }

}

