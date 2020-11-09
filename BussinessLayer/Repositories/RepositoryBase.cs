using AutoMapper;
using BussinessLayer.Mapping;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer.Interfaces;

namespace BussinessLayer.Repositories
{
    public class RepositoryBase<TS,TD> : IRepositoryBase<TS,TD>
        where TS : class
        where TD : class
    {
        protected readonly LNBagShopDBEntities _context;
        protected IMapper Mapper;
        public RepositoryBase(LNBagShopDBEntities context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            Mapper = config.CreateMapper();
        }
        public virtual void Add(ref TD entity)
        {
            TS SourceEntity = Mapper.Map<TD,TS>(entity);
            _context.Set<TS>().Add(SourceEntity);
        }

        public virtual IEnumerable<TD> Find(Expression<Func<TS, bool>> expression)
        {
            var totalResult = _context.Set<TS>().Where(expression);
            return Mapper.Map<List<TS>, List<TD>>(totalResult.ToList());
        }

        public IEnumerable<TD> getAll()
        {
            return Mapper.Map<List<TS>, List<TD>>(_context.Set<TS>().ToList());
        }

        public virtual TD getByID(int id)
        {
            return Mapper.Map<TS,TD>(_context.Set<TS>().Find(id));
        }

        public virtual void Remove(int id)
        {
            _context.Set<TS>().Remove(_context.Set<TS>().Find(id));
        }
    }
}
