using GRNCars.DAL.Abstract;
using GRNCars.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GRNCars.DAL.Concrete
{
    public class CarRepository : Repository<Vehicle>, ICarRepository
    {
        public CarRepository(DataBaseContext context) : base(context)
        {
        }

        public async Task<Vehicle> GetCustomCar(int id)
        {
            return await _dbSet.AsNoTracking().Include(x => x.Brand).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Vehicle>> GetCustomCarList()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Vehicle>> GetCustomCarList(Expression<Func<Vehicle, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Brand).ToListAsync();
        }
    }
}
