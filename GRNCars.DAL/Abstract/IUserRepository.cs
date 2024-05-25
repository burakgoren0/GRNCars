using GRNCars.Entities;
using System.Linq.Expressions;

namespace GRNCars.DAL.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<List<User>> GetCustomList();
        Task<List<User>> GetCustomList(Expression<Func<User, bool>> expression);
    }
}
