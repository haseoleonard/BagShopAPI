using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interfaces
{
    public interface IRepositoryBase<TS,TD>
        where TS:class
        where TD:class
    {
        IEnumerable<TD> getAll();
        TD getByID(int id);
        IEnumerable<TD> Find(Expression<Func<TS,bool>>expression);
        void Add(ref TD entity);
        void Remove(int id);
    }
}
