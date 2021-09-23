using System;
using System.Collections.Generic;
using SDM.Compulsory1.Core.Models;
using SDM.Compulsory1.Domain.IRepositories;

namespace SDM.Compulsory1.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private List<Review> reviews= new List<Review>(){ 
            new Review { Reviewer = 1, Movie = 1, Grade = 4, ReviewDate = DateTime.Now.AddDays(-180)},
            new Review { Reviewer = 2, Movie = 3, Grade = 4, ReviewDate = DateTime.Now.AddDays(-18)},
            new Review { Reviewer = 3, Movie = 4, Grade = 5, ReviewDate = DateTime.Now.AddDays(-10)},
            new Review { Reviewer = 1, Movie = 2, Grade = 2, ReviewDate = DateTime.Now.AddDays(-100)},
            new Review { Reviewer = 1, Movie = 5, Grade = 5, ReviewDate = DateTime.Now.AddDays(-280)},
            new Review { Reviewer = 2, Movie = 1, Grade = 3, ReviewDate = DateTime.Now.AddDays(-180)},
            new Review { Reviewer = 2, Movie = 3, Grade = 2, ReviewDate = DateTime.Now.AddDays(-18)},
            new Review { Reviewer = 2, Movie = 4, Grade = 5, ReviewDate = DateTime.Now.AddDays(-10)},
            new Review { Reviewer = 2, Movie = 2, Grade = 1, ReviewDate = DateTime.Now.AddDays(-100)},
            new Review { Reviewer = 2, Movie = 5, Grade = 1, ReviewDate = DateTime.Now.AddDays(-280)},
            new Review { Reviewer = 3, Movie = 1, Grade = 1, ReviewDate = DateTime.Now.AddDays(-180)},
            new Review { Reviewer = 3, Movie = 3, Grade = 1, ReviewDate = DateTime.Now.AddDays(-18)},
            new Review { Reviewer = 3, Movie = 5, Grade = 2, ReviewDate = DateTime.Now.AddDays(-10)},
            new Review { Reviewer = 4, Movie = 4, Grade = 3, ReviewDate = DateTime.Now.AddDays(-100)},
            new Review { Reviewer = 4, Movie = 3, Grade = 2, ReviewDate = DateTime.Now.AddDays(-280)},
            new Review { Reviewer = 4, Movie = 2, Grade = 3, ReviewDate = DateTime.Now.AddDays(-180)},
            new Review { Reviewer = 4, Movie = 1, Grade = 4, ReviewDate = DateTime.Now.AddDays(-18)},
            new Review { Reviewer = 5, Movie = 3, Grade = 4, ReviewDate = DateTime.Now.AddDays(-10)},
            new Review { Reviewer = 5, Movie = 2, Grade = 4, ReviewDate = DateTime.Now.AddDays(-100)},
            new Review { Reviewer = 5, Movie = 1, Grade = 5, ReviewDate = DateTime.Now.AddDays(-280)},
        };

        
        
        public IEnumerable<Review> GetAll()
        {
            return reviews;
        }

        public Review GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Review p)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Review p)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Review p)
        {
            throw new System.NotImplementedException();
        }
    }
}