using Wander_wisdom.Models;

namespace Wander_wisdom.Interface
{
    public interface IUserDetails
    {
        string UserRegistration(UserDetail user);

        UserDetail UserLogin(UserDetail user);

    }
}
