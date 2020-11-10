using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class OrderDetail
    {
        public string orderID { get; set; }
        [Required]
        public int productID { get; set; }
        public string productName { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public long total { get; set; }
    }
}
