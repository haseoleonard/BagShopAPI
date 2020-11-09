using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BussinessLayer.UnitOfWork;
using BussinessLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrgin")]
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
            return StatusCode(StatusCodes.Status302Found,category);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromForm] Category category)
        {
            try
            {
                _unitOfWork.Categories.Add(ref category);
                return StatusCode(StatusCodes.Status201Created,category);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }            
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromForm] Category category)
        {
            if (category.categoryID < 0 || category.categoryID > int.MaxValue || _unitOfWork.Categories.getByID(category.categoryID) == null||category.categoryName.Trim().Length==0)
                return StatusCode(StatusCodes.Status406NotAcceptable);
            try
            {
                var updatedCate = _unitOfWork.Categories.updateCategory(category);
                return StatusCode(StatusCodes.Status202Accepted, updatedCate);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
