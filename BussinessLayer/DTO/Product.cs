using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class Product
    {
        public int productID { get; set; }
        [Required]
        public string productName { get; set; }
        public string image { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public long price { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        [Required]
        public bool status { get; set; }
    }
}
