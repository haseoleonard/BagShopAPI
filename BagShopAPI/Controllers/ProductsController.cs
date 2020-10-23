using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BussinessLayer.DAO;
using BussinessLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            ProductsDAO productsDAO = new ProductsDAO();
            return productsDAO.GetProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Product))]
        public ActionResult<Product> Get(int id)
        {
            ProductsDAO productsDAO = new ProductsDAO();
            Product product = productsDAO.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
