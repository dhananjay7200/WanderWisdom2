using Wander_wisdom.Interface;
using Wander_wisdom.Models;

namespace Wander_wisdom.Repository
{
    public class PostDetailsRepo : IPostDetails
    {
        private readonly WanderWisdomContext _context;

        public PostDetailsRepo(WanderWisdomContext context)
        {
            _context = context;
        }
        public string AddPost(PostDetail postDetail)
        {

            try
            {
                _context.PostDetails.Add(postDetail);
                _context.SaveChanges();

            }catch (Exception ex)
            {
                throw new Exception("error in adding post");
            }
            return "Post Added";
        }

        public string DeletePost(int id)
        {
            PostDetail findPost=new PostDetail();
            try
            {
                findPost = _context.PostDetails.Where(x => ( x.PostId== id)).FirstOrDefault();  
            }catch(Exception ex)
            {
                throw new Exception("error while deletiing post");
            }
            return "deleted post ";
        }
    }
}
