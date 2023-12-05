using Wander_wisdom.Models;

namespace Wander_wisdom.Interface
{
    public interface IPostDetails
    {
        string AddPost(PostDetail postDetail);

        string DeletePost(int id);
    }
}
