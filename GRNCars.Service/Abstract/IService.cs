using GRNCars.DAL.Abstract;
using GRNCars.Entities;

namespace GRNCars.BL.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {

    }
}
