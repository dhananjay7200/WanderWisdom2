using Wander_wisdom.Models;

namespace Wander_wisdom.Interface
{
    public interface ILikesDetails
    {
        Task<LikesDetail> GetLikesDetalis(int id);


    }
}
