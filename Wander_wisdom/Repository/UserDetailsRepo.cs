using Microsoft.EntityFrameworkCore;
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
        public async Task<UserDetail> UserLogin(UserDetail user)
        {
            UserDetail udata=new UserDetail();


            try
            {
               udata = await _context.UserDetails.Where(x => (x.UserEmail == user.UserEmail && x.UserPassword==user.UserPassword )).FirstAsync();
            
            }catch(Exception ex)
            {
                throw new Exception("Error in login repo");
            }
            return udata;
        }

        public async Task<string> UserRegistration(UserDetail user)
        {
            try
            {
               await _context.UserDetails.AddAsync(user);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("Error in registration");
            }
            return "Registered";
        }


    }
}
