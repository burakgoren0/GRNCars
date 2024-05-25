using GRNCars.BL.Abstract;
using GRNCars.DAL;
using GRNCars.DAL.Concrete;

namespace GRNCars.BL.Concrete
{
    public class CarService : CarRepository, ICarService
    {
        public CarService(DataBaseContext context) : base(context)
        {
        }
    }
}
