using System;
using System.Collections.Generic;
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
        
        [Fact]
        public void TestForTopNMoviesBasedOnAverageRating()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue = { new Review {Movie = 1, Grade = 5},
                new Review {Movie = 1, Grade = 5},
                new Review {Movie = 1, Grade = 5},
                new Review {Movie = 1, Grade = 5},
                new Review {Movie = 1, Grade = 5},
                new Review {Movie = 2, Grade = 5},
                new Review {Movie = 2, Grade = 4},
                new Review {Movie = 3, Grade = 3},
                new Review {Movie = 3, Grade = 3},
                new Review {Movie = 4, Grade = 2},
                new Review {Movie = 4, Grade = 2},
                new Review {Movie = 5, Grade = 2},
                new Review {Movie = 5, Grade = 1},
                new Review {Movie = 5, Grade = 1},
                new Review {Movie = 6, Grade = 1},
                new Review {Movie = 6, Grade = 1}
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            List<int> actualResult = mService.GetTopRatedMovies(5);

            mock.Verify(m => m.GetAll(), Times.Once);
            
            Assert.Collection(actualResult,
                item => Assert.Equal(1, item),
                item => Assert.Equal(2, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(4,item),
                item => Assert.Equal(5, item)
            );
        }
        
        
        [Fact]
        public void TestForTopMovieByReviewer()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue = { new Review {Reviewer = 1, Movie = 1, Grade = 1, ReviewDate = DateTime.Now.AddDays(-200)},
                new Review {Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now.AddDays(-100)},
                new Review {Reviewer = 1, Movie = 3, Grade = 2, ReviewDate = DateTime.Now.AddDays(-150)}, 
                new Review {Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now.AddDays(-20)},
                new Review {Reviewer = 1, Movie = 4, Grade = 2, ReviewDate = DateTime.Now.AddDays(-80)},
                new Review {Reviewer = 3, Movie = 1, Grade = 1, ReviewDate = DateTime.Now.AddDays(-90)} 
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            List<int> actualResult = mService.GetTopMoviesByReviewer(1);

            mock.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult.Count == 4);
            Assert.Collection(actualResult,
                item => Assert.Equal(2, item),
                item => Assert.Equal(4, item),
                item => Assert.Equal(3, item),
                item => Assert.Equal(1,item)
            );
        }
        
        [Fact]
        public void TestForReviewersOnGivenMovie()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue = { new Review {Reviewer = 1, Movie = 1},
                new Review {Reviewer = 3, Movie = 1},
                new Review {Reviewer = 2, Movie = 2} 
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            List<int> actualResult = mService.GetReviewersByMovie(1);

            mock.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult.Count == 2);
            Assert.Contains(returnValue[0].Reviewer, actualResult);
            Assert.Contains(returnValue[1].Reviewer, actualResult);
        }
    }
}