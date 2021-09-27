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
        public void TestForNumberOfReviewsA()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            int actualResult = mService.GetNumberOfReviewsFromReviewer(1);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 6);

        }
        
        [Fact]
        public void TestForNumberOfReviewsB()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 2, Grade = 2, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            int actualResult = mService.GetNumberOfReviewsFromReviewer(1);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 4);

        }

        [Fact]
        public void TestForNegativeReviewId()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 2, Grade = 2, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            var result = 
                Assert.Throws<ArgumentException>(() => mService.GetNumberOfReviewsFromReviewer(-5));

            //Assert
            Assert.Equal("Invalid input!", result.Message);
            
        }
        
        [Fact]
        public void TestForInvalidReviewerId()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 2, Grade = 2, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            var result = 
                Assert.Throws<ArgumentException>(() => mService.GetNumberOfReviewsFromReviewer(9999));

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);
            Assert.Equal("No Reviewer with that ID exist in the database!", result.Message);
            
        }

        
        // GetAverageRateFromReviewer()
        [Fact]
        public void TestForAverageRateFromReviewerA()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetAverageRateFromReviewer(1);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 2);
        }
        
        [Fact]
        public void TestForAverageRateFromReviewerB()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 1, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 1, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 5, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 5, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 5, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetAverageRateFromReviewer(1);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 3);
        }

        // GetNumberOfRatesByReviewer

        [Fact]
        public void TestForNumberOfRatesFromReviewer()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 2, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 3, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 4, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 6, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetNumberOfRatesByReviewer(1, 2);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 7);
        }
        
        
        // GetNumberOfReviews
        
        [Fact]
        public void GetNumberOfReviews()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetNumberOfReviews(7);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 7);
        }

        // GetAverageRateOfMovie
        
        [Fact]
        public void GetAverageRateOfMovie()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetAverageRateOfMovie(7);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 2);
        }
        
        // GetNumberOfRates
        
        [Fact]
        public void GetNumberOfRates()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            int actualResult = mService.GetNumberOfRates(7, 2);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);
            
            Assert.True(actualResult == 7);
        }
        
        // GetMoviesWithHighestNumberOfTopRates
        
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRates()
        {
            throw new System.NotImplementedException();
        }

        // GetMostProductiveReviewers

        [Fact]
        public void GetMostProductiveReviewers()
        {

            throw new System.NotImplementedException();
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