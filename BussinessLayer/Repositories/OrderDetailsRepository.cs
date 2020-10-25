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
    }
}
