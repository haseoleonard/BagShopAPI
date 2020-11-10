using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using BussinessLayer.DTO;
using BussinessLayer.UnitOfWork;
using BussinessLayer.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BagShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class OrdersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _unitOfWork.Orders.getAll();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        [ResponseType(typeof(Order))]
        public IActionResult Get(string id)
        {
            var returnValue = _unitOfWork.Orders.GetOrder(id);
            if (returnValue == null) return NotFound();
            return Ok(returnValue);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            try
            {
                bool valid = true;
                string orderID = GeneratingHelperes.IDGenerating();
                List<OrderDetail> failedList = null;
                foreach (var item in order.OrderDetails)
                {
                    var inStockProduct = _unitOfWork.Products.getByID(item.productID);
                    if (item.quantity > inStockProduct.quantity)
                    {
                        valid = false;
                        if (failedList == null) failedList = new List<OrderDetail>();
                        item.quantity = inStockProduct.quantity;
                        failedList.Add(item);
                    }                        
                    item.orderID = orderID;
                    item.total = item.quantity * inStockProduct.price;
                    order.total += item.total;
                }
                if (valid)
                {
                    order.orderID = orderID;
                    order.orderDate = DateTime.Now;
                    _unitOfWork.Orders.Add(ref order);
                    if (_unitOfWork.Save() == order.OrderDetails.Count + 1)
                    {
                        Order newOrder = _unitOfWork.Orders.GetOrder(orderID);
                        return StatusCode(StatusCodes.Status201Created, newOrder);
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status406NotAcceptable);
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, failedList);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
