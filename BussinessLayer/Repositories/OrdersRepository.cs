using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;

namespace BussinessLayer.Repositories
{
    public class OrdersRepository:RepositoryBase<DataAccessLayer.Order,DTO.Order>,IOrdersRepository
    {
        public OrdersRepository(LNBagShopDBEntities context) : base(context)
        {
        }
        public DTO.Order GetOrder(string orderID)
        {
            return Mapper.Map<DataAccessLayer.Order,DTO.Order>(_context.Orders.Find(orderID));
        }
    }
}
