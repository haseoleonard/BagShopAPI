using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IOrdersRepository:IRepositoryBase<DataAccessLayer.Order,DTO.Order>
    {
        DTO.Order GetOrder(string orderID);
    }
    
}
