using Wander_wisdom.Interface;
using Wander_wisdom.Models;

namespace Wander_wisdom.Repository
{
    public class LikesDetailsRepo : ILikesDetails
    {
        private readonly WanderWisdomContext _context;

        public LikesDetailsRepo(WanderWisdomContext context)
        {
            _context = context;
        }


        public async Task<LikesDetail> GetLikesDetalis(int id)
        {
            LikesDetail Commdata = new LikesDetail();
            try
            {
                Commdata = await _context.LikesDetails.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in comments repo");
            }
            return Commdata;
        }
    }
}
