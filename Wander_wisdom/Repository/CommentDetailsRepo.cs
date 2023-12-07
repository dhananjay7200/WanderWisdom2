using Wander_wisdom.Interface;
using Wander_wisdom.Models;

namespace Wander_wisdom.Repository
{
    public class CommentDetailsRepo : ICommentsDetails
    {
        private readonly WanderWisdomContext _context;

        public CommentDetailsRepo(WanderWisdomContext context)
        {
            _context = context;
        }


        public async Task<CommentsDetail> GetCommentsDetails(int id)
        {
            CommentsDetail Commdata=new CommentsDetail();
            try
            {
                Commdata= await _context.CommentsDetails.FindAsync(id);
            }catch(Exception ex)
            {
                throw new Exception("Error in comments repo");
            }
            return Commdata;
        }
    }
}
