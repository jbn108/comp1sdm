using System.Collections.Generic;
using SDM.Compulsory1.Core.Models;

namespace SDM.Compulsory1.Domain.IRepositories
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetAll();

        Review GetById(int id);

        void Insert(Review p);

        void Update(Review p);

        void Delete(Review p);
    }
}