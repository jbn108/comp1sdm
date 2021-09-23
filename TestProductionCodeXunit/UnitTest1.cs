using System;
using Moq;
using SDM.Compulsory1.Core.Models;
using SDM.Compulsory1.Domain.IRepositories;
using SDM.Compulsory1.Domain.Services;
using SDM.Compulsory1.Infrastructure.Repositories;
using Xunit;

namespace TestProductionCodeXunit
{
    public class UnitTest1
    {
        // Test: GetNumberOfReviewsForReviewer()
        
        [Fact]
        public void TestForNumberOfReviews()
        {
            IReviewRepository reviewRepository = new ReviewRepository();
            ReviewService reviewService = new ReviewService(reviewRepository);

            int numberOfReviews = 0;

        }
    }
}