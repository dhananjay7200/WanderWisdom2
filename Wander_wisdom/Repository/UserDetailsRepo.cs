using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Wander_wisdom.Interface;
using Wander_wisdom.Models;

namespace Wander_wisdom.Repository
{
    public class UserDetailsRepo : IUserDetails
    {
        private readonly WanderWisdomContext _context;
        private readonly IConfiguration iconfiguration;
        public UserDetailsRepo(WanderWisdomContext context, IConfiguration iconfiguration)
        {
            _context = context;
            this.iconfiguration = iconfiguration;
        }



        public async Task<string> UserLogin(Logindetails user)
        {
            UserDetail udata=new UserDetail();


            try
            {
               udata = await _context.UserDetails.Where(x => (x.UserEmail == user.User_Email && x.UserPassword==user.Password )).FirstAsync();
                if (udata != null)
                {
                    var token = GenerateToken(udata);
                    return token;
                }
                
            
            }catch(Exception ex)
            {
                throw new Exception("Error in login repo");
            }
            return "no user found";
        }

        public async Task<string> UserRegistration(UserDetail user)
        {
            try
            {
               await _context.UserDetails.AddAsync(user);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception(ex +"Error in registration");
            }
            return "Registered";
        }


        public async Task<string> DeleteUser(int id)
        {
            try
            {
                UserDetail Udata=await _context.UserDetails.FindAsync(id);
                if (Udata!=null)
                {
                    Udata.IsDeleted = 0;
                    _context.SaveChanges();
                    return "";
                }
                else
                {
                    return "";
                }

            }catch(Exception ex)
            {
                throw new Exception(ex + "error in delete user repo");
            }
        }

        private string GenerateToken(UserDetail user)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                  new Claim("email",user.UserEmail),
                  new Claim("role", user.UserRole),
                   new Claim("id", user.UserIdPk.ToString()),
                   new Claim("name",user.UserName),
              };
            var token = new JwtSecurityToken(iconfiguration["Jwt:Issuer"],
                iconfiguration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }






    }
}
