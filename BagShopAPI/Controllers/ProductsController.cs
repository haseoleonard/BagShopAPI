using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BussinessLayer.DAO;
using BussinessLayer.DTO;
using BussinessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productRepository.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Product))]
        public ActionResult<Product> Get(int id)
        {
            var product = _productRepository.getByID(id);
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
