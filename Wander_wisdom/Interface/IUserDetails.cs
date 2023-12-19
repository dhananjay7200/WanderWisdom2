using Wander_wisdom.Models;

namespace Wander_wisdom.Interface
{
    public interface IUserDetails
    {
        Task<string> UserRegistration(UserDetail user);

        Task<string> UserLogin(Logindetails user);

        Task<string> DeleteUser(int it);

    }
}
