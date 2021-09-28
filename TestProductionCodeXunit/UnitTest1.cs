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
        
        [Fact]
        public void TestForNegativeReviewIdForMethodTwo()
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
                Assert.Throws<ArgumentException>(() => mService.GetAverageRateFromReviewer(-5));

            //Assert
            Assert.Equal("Invalid input!", result.Message);
            
        }
        
        [Fact]
        public void TestForInvalidReviewerIdForMethodTwo()
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
                Assert.Throws<ArgumentException>(() => mService.GetAverageRateFromReviewer(9999));

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);
            Assert.Equal("No Reviewer with that ID exist in the database!", result.Message);
            
        }

        // GetNumberOfRatesByReviewer

        [Fact]
        public void TestForNumberOfRatesFromReviewer()
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
            double actualResult = mService.GetNumberOfRatesByReviewer(1, 2);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 4);
        }
        
        [Fact]
        public void TestForNumberOfRatesFromReviewerNoRatingCase()
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
            double actualResult = mService.GetNumberOfRatesByReviewer(1, 5);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 0);
        }
        
        [Fact]
        public void TestForNumberOfRatesFromReviewerNegativeReviewId()
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
                Assert.Throws<ArgumentException>(() => mService.GetNumberOfRatesByReviewer(-5, 2));

            //Assert
            Assert.Equal("Invalid input!", result.Message);
            
        }
        
        [Fact]
        public void TestForNumberOfRatesFromReviewerInvalidRateLOW()
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
                Assert.Throws<ArgumentException>(() => mService.GetNumberOfRatesByReviewer(1, -5));

            //Assert
            Assert.Equal("Invalid input!", result.Message);
            
        }
        
        [Fact]
        public void TestForNumberOfRatesFromReviewerInvalidRateHIGH()
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
                Assert.Throws<ArgumentException>(() => mService.GetNumberOfRatesByReviewer(1, 8));

            //Assert
            Assert.Equal("Invalid input!", result.Message);
            
        }
        
        // GetNumberOfReviews
        
        [Fact]
        public void GetNumberOfReviews()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 2, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 2, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetNumberOfReviews(7);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 4);
        }
        
        [Fact]
        public void GetNumberOfReviewsNoReviews()
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 5, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now},
                new Review() {Reviewer = 1, Grade = 2, Movie = 7, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            //Act
            double actualResult = mService.GetNumberOfReviews(6);

            //Assert
            m.Verify(m => m.GetAll(), Times.Once);

            Assert.True(actualResult == 0);
        }
        
        [Fact]
        public void GetNumberOfReviewsInvalidMovieId()
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
            var result = 
                Assert.Throws<ArgumentException>(() => mService.GetNumberOfReviews(-5));

            //Assert
            Assert.Equal("Invalid input!", result.Message);
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
        
        [Fact]
        public void GetNumberOfRatesIfRateIsNegative()
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
            
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => mService.GetNumberOfRates(7,-2));

            Assert.Equal("Rate must fit within 1-5", ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesIfRateIsAboveUpperBound()
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
            
            //Assert
            var ex = Assert.Throws<ArgumentException>(() => mService.GetNumberOfRates(7,6));

            Assert.Equal("Rate must fit within 1-5", ex.Message);
        }
        
        [Fact]
        public void GetNumberOfRatesIfMovieIdDoesNotExist()
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

            //Assert
            var ex = Assert.Throws<ArgumentException>(() => mService.GetNumberOfRates(0,2));

            Assert.Equal("Movie with given id does not exist", ex.Message);
        }
        // GetMoviesWithHighestNumberOfTopRates

        [Theory]

        //Reviewer, Grade, Movie
        [InlineData(
            1, 2, 3,
            4, 5, 6,
            7, 8, 9,
        new int[] { 6 })]
        [InlineData(
            9, 8, 7,
            6, 5, 4,
            3, 2, 1,
        new int[] { 4 })]
        [InlineData(
            5, 5, 5,
            5, 5, 5,
            5, 5, 5,
        new int[] { 5 })]
        [InlineData(
            0, 0, 0,
            0, 0, 0,
            0, 0, 0,
        new int[] { })]
        [InlineData(
            5, 5, 3,
            5, 5, 5,
            5, 5, 6,
        new int[] { 3, 5, 6 })]
        public void GetMoviesWithHighestNumberOfTopRates(
        int a, int b, int c,
        int a1, int b1, int c1,
        int a2, int b2, int c2,
        int[] expectedResult)
        {
            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();

            Review[] returnValue =
            {
                new Review() {Reviewer = a, Grade = b, Movie = c, ReviewDate = DateTime.Now},
                new Review() {Reviewer = a1, Grade = b1, Movie = c1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = a2, Grade = b2, Movie = c2, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);

            ReviewService mService = new ReviewService(m.Object);

            // Check that the method returns a list
            Assert.IsType<List<int>>(mService.GetMoviesWithHighestNumberOfTopRates());


            //Check that it returns the expected result
            List<int> expResult = new List<int>();
            foreach (var i in expectedResult)
                expResult.Add(i);
            Assert.Equal(mService.GetMoviesWithHighestNumberOfTopRates(), expResult);
        }

        // GetMostProductiveReviewers

        [Theory]

        //Reviewer, Grade, Movie
        [InlineData(
            1, 2, 3,
            4, 5, 6,
            7, 2, 9,
        new int[] { 1, 4, 7 })]
        [InlineData(
            9, 2, 7,
            6, 5, 4,
            3, 2, 1,
        new int[] { 9, 6, 3 })]
        [InlineData(
            5, 5, 5,
            5, 5, 5,
            5, 5, 5,
        new int[] { 5 })]
        [InlineData(
            0, 0, 0,
            0, 0, 0,
            0, 0, 0,
        new int[] { 0 })]
        [InlineData(
            5, 5, 3,
            5, 5, 5,
            5, 5, 6,
        new int[] { 5 })]
        public void GetMostProductiveReviewers(
            int a, int b, int c,
            int a1, int b1, int c1,
            int a2, int b2, int c2,
            int[] expectedResult
        )
        {

            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();
            Review[] returnValue =
            {
                new Review() {Reviewer = a, Grade = b, Movie = c, ReviewDate = DateTime.Now},
                new Review() {Reviewer = a1, Grade = b1, Movie = c1, ReviewDate = DateTime.Now},
                new Review() {Reviewer = a2, Grade = b2, Movie = c2, ReviewDate = DateTime.Now}
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);


            ReviewService mService = new ReviewService(m.Object);


            // Check that the method returns a list
            Assert.IsType<List<int>>(mService.GetMostProductiveReviewers());


            //Check that it returns the expected result
            List<int> expResult = new List<int>();
            foreach (var i in expectedResult)
                expResult.Add(i);
            Assert.Equal(mService.GetMostProductiveReviewers(), expResult);
        }

        [Fact]
        public void GetMostProductiveReviewersButIsEmptyTest()
        {


            //Arrange
            Mock<IReviewRepository> m = new Mock<IReviewRepository>();
            Review[] returnValue =
            {
            };
            m.Setup(m => m.GetAll()).Returns(() => returnValue);


            ReviewService mService = new ReviewService(m.Object);


            // Should throw an exception since the list of reviewers is empty.
            Assert.Throws<InvalidOperationException>(() => mService.GetMostProductiveReviewers());

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
        public void TestForTopNMoviesBasedOnAverageRatingWithLessThan1N()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue =
            {
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 2, Grade = 5 },
                new Review { Movie = 2, Grade = 4 },
                new Review { Movie = 3, Grade = 3 },
                new Review { Movie = 3, Grade = 3 },
                new Review { Movie = 4, Grade = 2 },
                new Review { Movie = 4, Grade = 2 },
                new Review { Movie = 5, Grade = 2 },
                new Review { Movie = 5, Grade = 1 },
                new Review { Movie = 5, Grade = 1 },
                new Review { Movie = 6, Grade = 1 },
                new Review { Movie = 6, Grade = 1 }
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            var ex = Assert.Throws<ArgumentException>(() => mService.GetTopRatedMovies(0));

            Assert.Equal("Param needs to be 1 or above.", ex.Message);
        }

        [Fact]
        public void TestForTopNMoviesBasedOnAverageRatingWithAboveUpperBound()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue =
            {
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 1, Grade = 5 },
                new Review { Movie = 2, Grade = 5 },
                new Review { Movie = 2, Grade = 4 },
                new Review { Movie = 3, Grade = 3 },
                new Review { Movie = 3, Grade = 3 },
                new Review { Movie = 4, Grade = 2 },
                new Review { Movie = 4, Grade = 2 },
                new Review { Movie = 5, Grade = 2 },
                new Review { Movie = 5, Grade = 1 },
                new Review { Movie = 5, Grade = 1 },
                new Review { Movie = 6, Grade = 1 },
                new Review { Movie = 6, Grade = 1 }
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => mService.GetTopRatedMovies(7));

            Assert.Equal(
                "Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')",
                ex.Message);
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
        public void TestForTopMovieByReviewerIfReviewerDoesNotExist()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue =
            {
                new Review { Reviewer = 1, Movie = 1, Grade = 1, ReviewDate = DateTime.Now.AddDays(-200) },
                new Review { Reviewer = 1, Movie = 2, Grade = 5, ReviewDate = DateTime.Now.AddDays(-100) },
                new Review { Reviewer = 1, Movie = 3, Grade = 2, ReviewDate = DateTime.Now.AddDays(-150) },
                new Review { Reviewer = 2, Movie = 1, Grade = 5, ReviewDate = DateTime.Now.AddDays(-20) },
                new Review { Reviewer = 1, Movie = 4, Grade = 2, ReviewDate = DateTime.Now.AddDays(-80) },
                new Review { Reviewer = 3, Movie = 1, Grade = 1, ReviewDate = DateTime.Now.AddDays(-90) }
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            var ex = Assert.Throws<ArgumentException>(() => mService.GetTopMoviesByReviewer(0));

            Assert.Equal("Reviewer With id does not exist", ex.Message);
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
        
        [Fact]
        public void TestForReviewersOnGivenMovieIfMovieDoesNotExist()
        {
            Mock<IReviewRepository> mock = new Mock<IReviewRepository>();

            ReviewService mService = new ReviewService(mock.Object);

            Review[] returnValue =
            {
                new Review { Reviewer = 1, Movie = 1 },
                new Review { Reviewer = 3, Movie = 1 },
                new Review { Reviewer = 2, Movie = 2 }
            };

            mock.Setup(m => m.GetAll()).Returns(() => returnValue);

            var ex = Assert.Throws<ArgumentException>(() => mService.GetReviewersByMovie(0));

            Assert.Equal("Movie With id does not exist", ex.Message);
        }
    }
}
