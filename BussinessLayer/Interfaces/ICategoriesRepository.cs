using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface ICategoriesRepository:IRepositoryBase<DataAccessLayer.Category,DTO.Category>
    {
        DTO.Category updateCategory(DTO.Category category);
    }
}
