using GRNCars.BL.Abstract;
using GRNCars.DAL;
using GRNCars.DAL.Concrete;

namespace GRNCars.BL.Concrete
{
    public class UserService : UserRepository, IUserService
    {
        public UserService(DataBaseContext context) : base(context)
        {
        }
    }
}
