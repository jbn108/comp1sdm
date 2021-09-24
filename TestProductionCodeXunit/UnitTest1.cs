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
            int actualResult = mService.GetNumberOfReviewsFromReviewer(1);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == returnValue.Length);

        }

        
        // GetAverageRateFromReviewer()
        [Fact]
        public void TestForAverageRateFromReviewer()
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
    }
}