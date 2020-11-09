using BussinessLayer.Interfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repositories
{
    public class OrderDetailsRepository: RepositoryBase<DataAccessLayer.OrderDetail,DTO.OrderDetail>,IOrderDetailsRepository
    {
        public OrderDetailsRepository(LNBagShopDBEntities context) : base(context)
        {
        }
        public void AddRange(ICollection<DTO.OrderDetail> orderDetails)
        {
            ICollection<DataAccessLayer.OrderDetail> details = Mapper.Map<ICollection<DTO.OrderDetail>,ICollection<DataAccessLayer.OrderDetail> >(orderDetails);
            _context.OrderDetails.AddRange(details);
        }
    }
}
