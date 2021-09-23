using SDM.Compulsory1.Core.IServices;
using SDM.Compulsory1.Domain.IRepositories;

namespace SDM.Compulsory1.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repo;

        public ReviewService(IReviewRepository reviewRepo)
        {
            _repo = reviewRepo;
        }


        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }
    }
}