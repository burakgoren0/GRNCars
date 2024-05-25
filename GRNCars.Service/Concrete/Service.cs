using GRNCars.BL.Abstract;
using GRNCars.DAL;
using GRNCars.DAL.Concrete;
using GRNCars.Entities;

namespace GRNCars.BL.Concrete
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DataBaseContext context) : base(context)
        {

        }
    }
}
