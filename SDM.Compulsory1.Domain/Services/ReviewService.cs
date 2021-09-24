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
            int numberOfReviews = 0;
            foreach (var r in _repo.GetAll())
            {
                if (r.Reviewer == reviewer)
                {
                    numberOfReviews++;
                }
            }

            return numberOfReviews;
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            int sum = 0;
            int numberOfReviews = 0;
            
            foreach (var r in _repo.GetAll().Where(r => r.Reviewer == reviewer).ToList())
            {
                sum += r.Grade;
                numberOfReviews++;
            }

            return sum / numberOfReviews;
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            int numberOfRates = 0;
            foreach (var r in _repo.GetAll().Where(r => r.Reviewer == reviewer))
            {
                if (r.Grade == rate)
                {
                    numberOfRates++;
                }
            }
            return numberOfRates;
        }

        public int GetNumberOfReviews(int movie)
        {
            return _repo.GetAll().Where(r => r.Movie == movie).ToList().Count;
        }

        public double GetAverageRateOfMovie(int movie)
        {
            int sum = 0;
            int numberOfReviews = 0;
            
            foreach (var r in _repo.GetAll().Where(r => r.Movie == movie).ToList())
            {
                sum += r.Grade;
                numberOfReviews++;
            }

            return sum / numberOfReviews;
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            int numberOfRates = 0;
            foreach (var r in _repo.GetAll().Where(r => r.Movie == movie))
            {
                if (r.Grade == rate)
                {
                    numberOfRates++;
                }
            }
            return numberOfRates;
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            Dictionary<int, int> topReviewers = new Dictionary<int, int>();
            
            foreach (var r in _repo.GetAll())
            {
                if (!topReviewers.ContainsKey(r.Reviewer))
                {
                    topReviewers.Add(r.Reviewer, 1);
                }
                else
                {
                    topReviewers[r.Reviewer] += 1;
                }
            }

            List<KeyValuePair<int, int>> revs = topReviewers.OrderByDescending(r => r.Value).ToList();
            List<int> final = new List<int>();
            
            final.Add(revs[0].Key);
            final.Add(revs[1].Key);
            final.Add(revs[2].Key);
            final.Add(revs[3].Key);
            final.Add(revs[4].Key);

            return final;
        }
    }
}