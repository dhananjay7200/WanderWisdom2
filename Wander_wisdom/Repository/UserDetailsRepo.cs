using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Wander_wisdom.Interface;
using Wander_wisdom.Models;

namespace Wander_wisdom.Repository
{
    public class UserDetailsRepo : IUserDetails
    {
        private readonly WanderWisdomContext _context;
        
        public UserDetailsRepo(WanderWisdomContext context)
        {
            _context = context;
        }
        public UserDetail UserLogin(UserDetail user)
        {
            UserDetail udata=new UserDetail();


            try
            {
               udata = _context.UserDetails.Where(x => (x.UserEmail == user.UserEmail && x.UserPassword==user.UserPassword )).FirstOrDefault();
            }catch(Exception ex)
            {
                throw new Exception("Error in login");
            }
            return udata;
        }

        public string UserRegistration(UserDetail user)
        {
            try
            {
                _context.UserDetails.Add(user);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("Error in registration");
            }
            return "Registered";
        }
    }
}
