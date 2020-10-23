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
    public class CategoriesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            CategoriesDAO categoriesDAO = new CategoriesDAO();
            return categoriesDAO.GetCategories();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Category))]
        public ActionResult<Category> Get(int id)
        {
            CategoriesDAO categoriesDAO = new CategoriesDAO();
            Category category = categoriesDAO.GetCategory(id);
            if(category==null)return NotFound();
            return Ok(category);
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
