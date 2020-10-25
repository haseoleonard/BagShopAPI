using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BussinessLayer.UnitOfWork;
using BussinessLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _unitOfWork.Categories.getAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Category))]
        public ActionResult<Category> Get(int id)
        {
            Category category = _unitOfWork.Categories.getByID(id);
            if(category==null)return NotFound();
            return Ok(category);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromForm] Category category)
        {
            try
            {
                _unitOfWork.Categories.Add(ref category);
                return Ok(category);
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
