using BussinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;

namespace BussinessLayer.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        ICategoriesRepository Categories { get; }
        IOrdersRepository Orders { get; }
        int Save();
    }
}
