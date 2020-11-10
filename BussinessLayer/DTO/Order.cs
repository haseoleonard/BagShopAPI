using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.DTO
{
    public class Order
    {
        [Key]
        public string orderID { get; set; }
        [Required]
        public string customerName { get; set; }
        [Required]
        public string customerAddress { get; set; }
        [Required]
        public string customerPhone { get; set; }
        public DateTime orderDate { get; set; }
        [Required]
        public bool paymentStatus { get; set; }
        [Required]
        public long total { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
