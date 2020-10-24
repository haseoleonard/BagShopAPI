using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public interface IRepositoryBase<TS,TD>
        where TS:class
        where TD:class
    {
        TD ConvertToDestinationType(TS entity);
        TS ConvertToSourceType(TD entity);
        IEnumerable<TD> getAll();
        TD getByID(int id);
        IEnumerable<TD> Find(Expression<Func<TD,bool>>expression);
        TD Add(TD entity);
        void Remove(int id);
    }
}
