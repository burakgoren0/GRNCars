using GRNCars.Entities;
using System.Linq.Expressions;

namespace GRNCars.DAL.Abstract
{
    public interface ICarRepository : IRepository<Vehicle>
    {
        Task<List<Vehicle>> GetCustomCarList();
        Task<List<Vehicle>> GetCustomCarList(Expression<Func<Vehicle, bool>> expression);
        Task<Vehicle> GetCustomCar(int id);
    }
}
