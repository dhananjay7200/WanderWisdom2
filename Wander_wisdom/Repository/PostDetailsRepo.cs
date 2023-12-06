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
        public async Task<string> AddPost(PostDetail postDetail)
        {

            try
            {
                await _context.PostDetails.AddAsync(postDetail);
                _context.SaveChanges();

            }catch (Exception ex)
            {
                throw new Exception("error in adding post");
            }
            return "Post Added";
        }

        public async Task<string> DeletePost(int id)
        {
            PostDetail findPost=new PostDetail();
            try
            {
                findPost =await  _context.PostDetails.FindAsync(id); 
                _context.PostDetails.Remove(findPost);
                _context.SaveChanges();
            }catch(Exception ex)
            {
                throw new Exception("error while deletiing post");
            }

            return "deleted post ";
        }
    }
}
