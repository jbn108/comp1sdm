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



            public List<int> GetTopRatedMovies(int amount)
            {
                var allReviews = _repo.GetAll().ToList();
                var movieRatingsDictionary = new Dictionary<int, List<int>>();
                var movieTotalRatingDictionary = new Dictionary<int, int>();

                //Loop igennem alle reviews og indsæt alle film i en dictionary.
                //hvis de ikke allerede er tilføjet til dictionaried så gør det, ellers så tilføj ratingen til value listen.
                foreach (var m in allReviews)
                {
                    if (!movieRatingsDictionary.ContainsKey(m.Movie))
                    {
                        movieRatingsDictionary.Add(m.Movie, new List<int>());
                    }
                    else
                    {
                        movieRatingsDictionary[m.Movie].Add(m.Grade);
                    }
                }

                //loop igennem alle keys i dictionaried med int listen.
                //Hvis ikke de er tilføjet til det nye dictionary, tilføj dem, ellers så loop igennem alle values i int listen
                // og summer dem til dens nye totale værdi. Derefter, så finder vi gennemsnittet ved at dividere med
                //længden af den gamle int liste i det gamle dictionary.
                foreach (var key in movieRatingsDictionary.Keys)
                {
                    if (!movieTotalRatingDictionary.ContainsKey(key))
                    {
                        movieTotalRatingDictionary.Add(key, 0);
                    }

                    foreach (var value in movieRatingsDictionary[key])
                    {
                        movieTotalRatingDictionary[key] += value;
                    }

                    movieTotalRatingDictionary[key] /= movieRatingsDictionary[key].Count;
                }

                //Sorter dictionaried baseret på den totale værdi og assign det til en liste af keyvaluepairs.
                List<KeyValuePair<int, int>> n = movieTotalRatingDictionary.OrderByDescending(r => r.Value).ToList();

                //Looper vi igennem N gange baseret på parameteren og tilføjer top N til listen af keys AKA Movie ID'et
                List<int> topN = new List<int>();
                for (int i = 0; i < amount; i++)
                {
                    topN.Add(n[i].Key);
                }

                return topN;
            }


            public List<int> GetTopMoviesByReviewer(int reviewer)
            {
                List<Review> movies = _repo.GetAll().ToList().FindAll(r => r.Reviewer == reviewer);

                var orderedMovies = movies.OrderByDescending(m => m.Grade).ThenByDescending(m => m.ReviewDate).ToList();

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





            public List<int> GetTopRatedMovies(int amount)
            {
                throw new System.NotImplementedException();
            }

            public List<int> GetTopMoviesByReviewer(int reviewer)
            {
                throw new System.NotImplementedException();
            }

            public List<int> GetReviewersByMovie(int movie)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}

