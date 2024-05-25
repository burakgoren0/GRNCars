using GRNCars.DAL.Abstract;
using GRNCars.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GRNCars.DAL.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task<List<User>> GetCustomList()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Role).ToListAsync();
        }

        public async Task<List<User>> GetCustomList(Expression<Func<User, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Role).ToListAsync();
        }
    }
}
