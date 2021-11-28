using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.DataAccess;
using WEBAPI.Entities;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {

        IProductDal _productDal;

        public ProductController(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [HttpGet]
        public IActionResult  Get()
        {
            var products = _productDal.GetList();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            try
            {
                var product = _productDal.Get(p => p.ProductId == productId);
                if (product == null)
                {
                    return NotFound($"product id ler eş değildir");
                }
                return Ok(product);
            }
            catch (Exception)
            {

               
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(Product product)  //Post([fromBody]Product product) 
        {
            try
            {
                _productDal.add(product);
                return new StatusCodeResult(201);
            }
            catch (Exception e)
            {

               
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put(Product product)  //Post([fromBody]Product product) 
        {
            try
            {
                _productDal.Update(product);
                return Ok(product);
            }
            catch (Exception e)
            {


            }
            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)  //Post([fromBody]Product product) 
        {
            try
            {
                _productDal.Delete(new Product {ProductId = productId });
                return Ok();
            }
            catch (Exception e)
            {


            }
            return BadRequest();
        }

        [HttpGet("GetProductDetails")]
        public IActionResult GetProductWithDetails()
        {
            try
            {
                var  result =_productDal.GetProductsWithDetails();
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
            return BadRequest();
        }
    }
}
