using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BussinessLayer.DTO;
using BussinessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BussinessLayer.DAO;
using Microsoft.AspNetCore.Http.Extensions;

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _unitOfWork.Products.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Product))]
        public ActionResult<Product> Get(int id)
        {
            var product = _unitOfWork.Products.getByID(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromForm] Product product)
        {
            //ProductsDAO productsDAO = new ProductsDAO();
            //var result = productsDAO.Add(product);
            try
            {
                _unitOfWork.Products.Add(ref product);
                return Ok(product);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }            
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
