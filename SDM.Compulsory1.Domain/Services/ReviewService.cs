using System.Collections.Generic;
using System.Linq;
using SDM.Compulsory1.Core.IServices;
using SDM.Compulsory1.Core.Models;
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
        
        public List<int> GetTopRatedMovies(int amount)
                {
                    throw new System.NotImplementedException();
                }
        
                public List<int> GetTopMoviesByReviewer(int reviewer)
                {
                    List<Review> movies = _repo.GetAll().ToList().FindAll(r => r.Reviewer == reviewer);
        
                    var orderedMovies  = movies.OrderByDescending(m => m.Grade).ThenByDescending(m => m.ReviewDate).ToList();
        
                    List<int> movieIds = new List<int>();
                    foreach (var m in orderedMovies)
                    {
                        movieIds.Add(m.Movie);
                    }
        
                    return movieIds;
                }
        
                public List<int> GetReviewersByMovie(int movie)
                {
                    List<int> reviewers = new List<int>();
        
                    foreach (var r in _repo.GetAll().ToList().FindAll(r => r.Movie == movie))
                    {
                        reviewers.Add(r.Reviewer);
                    }
        
                    return reviewers;
                }
    }
}