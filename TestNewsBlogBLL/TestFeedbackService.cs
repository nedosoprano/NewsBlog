using Moq;
using NewsBlogBLL.Services;
using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TestNewsBlog
{
    public class TestsFeedbackService
    {
        static Feedback feedback;
        static Mock<IRepository<Feedback>> mockFeedbacks;

        [SetUp]
        public void Setup()
        {
            feedback = new Feedback
            {
                Id = 1,
                AuthorName = "Nataliia",
                ReviewText = "The best news site!"
            };

            mockFeedbacks = new Mock<IRepository<Feedback>>();
            mockFeedbacks.Setup(frepo => frepo.CreateAsync(It.IsAny<Feedback>())).Returns(Task.FromResult(feedback));
            mockFeedbacks.Setup(frepo => frepo.UpdateAsync(It.IsAny<Feedback>())).Returns(Task.FromResult(true));
        }

        [Test]
        public void CreateAsync_CorrectValues_ReturnFeedback()
        {
            IService<Feedback> feedbackServices = new FeedbackService(mockFeedbacks.Object);

            Task<Feedback> newFb = feedbackServices.CreateAsync(new Feedback 
            {
                Id = 1,
                AuthorName = "Nataliia",
                ReviewText = "The best news site!"
            });

            Assert.AreEqual(newFb.Result, feedback);
        }

        [TestCase("")]
        [TestCase("nataliia")]
        [TestCase("soprano490")]
        public void CreateAsync_IncorrectAuthorName_ThrowArgumentException(string authorName)
        {
            IService<Feedback> feedbackServices = new FeedbackService(mockFeedbacks.Object);
            var expectedTypeError = typeof(ArgumentException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await feedbackServices.CreateAsync(new Feedback
                {
                    Id = 1,
                    AuthorName = authorName,
                    ReviewText = "The best news site!"
                });
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }

        [Test]
        public void UpdateAsync_ArgumentIsNull_ThrowArgumentNullException()
        {
            IService<Feedback> feedbackServices = new FeedbackService(mockFeedbacks.Object);
            var expectedTypeError = typeof(ArgumentNullException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await feedbackServices.UpdateAsync(null);
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }

        [Test]
        public void UpdateAsync_CorrectValues_ReturnTrue()
        {
            IService<Feedback> feedbackServices = new FeedbackService(mockFeedbacks.Object);
            var expectedResult = true;

            Task<bool> result = feedbackServices.UpdateAsync(feedback);

            Assert.AreEqual(result.Result, expectedResult);
        }
    }
}