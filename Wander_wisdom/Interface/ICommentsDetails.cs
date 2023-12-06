using Wander_wisdom.Models;

namespace Wander_wisdom.Interface
{
    public interface ICommentsDetails
    {
        Task<CommentsDetail> GetCommentsDetails(int id);

      

    }
}
