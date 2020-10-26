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
using System.IO;
using System.Runtime.Remoting.Contexts;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using BussinessLayer.Validation;

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _env;
        public ProductsController(IUnitOfWork unitOfWork,IHostingEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var list = _unitOfWork.Products.getAll();
            if (list.Count() > 0)
            {
                return StatusCode(StatusCodes.Status302Found, list);
            }
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Product))]
        public ActionResult<Product> Get(int id)
        {
            var product = _unitOfWork.Products.getByID(id);
            if (product == null) return NotFound();
            return StatusCode(StatusCodes.Status302Found,product);
        }
        // POST api/values
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Product product)
        {
            var file = Request.Form.Files[0];
            if (file!=null&&file.Length>0) {
                string webRootPath = _env.WebRootPath;
                string savePath = Path.Combine(webRootPath, "Images");
                if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(savePath, fileName);
                if (!System.IO.File.Exists(fullPath))
                {
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                product.image = fileName;
            }
            try
            {
                _unitOfWork.Products.Add(ref product);
                return StatusCode(StatusCodes.Status201Created,product);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }            
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromForm] Product product)
        {
            try
            {
                if (_unitOfWork.Products.getByID(product.productID) != null)
                {
                    if (ValidationService.isValidProduct(product))
                    {
                        var file = Request.Form.Files[0];
                        if (file != null && file.Length > 0)
                        {
                            if (file.ContentType.Contains("image"))
                            {
                                string webRootPath = _env.WebRootPath;
                                string savePath = Path.Combine(webRootPath, "Images");
                                if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);
                                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                                string fullPath = Path.Combine(savePath, fileName);
                                if (!System.IO.File.Exists(fullPath))
                                {
                                    using (var stream = new FileStream(fullPath, FileMode.Create))
                                    {
                                        file.CopyTo(stream);
                                    }
                                }
                                product.image = fileName;
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status415UnsupportedMediaType);
                            }
                        }
                        _unitOfWork.Products.UpdateProduct(product);
                        return StatusCode(StatusCodes.Status202Accepted, product);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status406NotAcceptable);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
