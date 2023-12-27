using Wander_wisdom.Models;

namespace Wander_wisdom.Interface
{
    public interface IPostDetails
    {
        Task<string> AddPost(PostDetail postDetail);

        Task<string> DeletePost(int id);

        Task<IEnumerable<PostDetail>> GetPost(int id);

        Task<IEnumerable<PostDetail>> GetAllPost();
    }
}
