using Moq;
using NewsBlogBLL.Services;
using NewsBlogDAL.Enums;
using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestNewsBlog
{
    public class TestQuestionnaireResultService
    {
        static QuestionnaireResult result;
        static Mock<IRepository<QuestionnaireResult>> mockResults;

        [SetUp]
        public void Setup()
        {
            result = new QuestionnaireResult
            {
                Id = 1,
                FirstName = "Nataliia",
                LastName = "Lynnyk",
                Sex = Sex.Female,
                Preferences = new List<Preference> { Preference.Animals, Preference.Sport }
            };

            mockResults = new Mock<IRepository<QuestionnaireResult>>();
            mockResults.Setup(frepo => frepo.CreateAsync(It.IsAny<QuestionnaireResult>())).Returns(Task.FromResult(result));
            mockResults.Setup(frepo => frepo.UpdateAsync(It.IsAny<QuestionnaireResult>())).Returns(Task.FromResult(true));
        }

        [Test]
        public void CreateAsync_CorrectValues_ReturnFeedback()
        {
            IService<QuestionnaireResult> questionnaireResultServices = new QuestionnaireResultService(mockResults.Object);

            Task<QuestionnaireResult> newResult = questionnaireResultServices.CreateAsync(new QuestionnaireResult
            {
                Id = 1,
                FirstName = "Nataliia",
                LastName = "Lynnyk",
                Sex = Sex.Female,
                Preferences = new List<Preference> { Preference.Animals, Preference.Sport }
            });

            Assert.AreEqual(newResult.Result, result);
        }

        [TestCase("")]
        [TestCase("nataliia")]
        [TestCase("soprano490")]
        public void CreateAsync_IncorrectName_ThrowArgumentException(string name)
        {
            IService<QuestionnaireResult> questionnaireResultServices = new QuestionnaireResultService(mockResults.Object);
            var expectedTypeError = typeof(ArgumentException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await questionnaireResultServices.CreateAsync(new QuestionnaireResult
                {
                    Id = 1,
                    FirstName = name,
                    LastName = "Lynnyk",
                    Sex = Sex.Female,
                    Preferences = new List<Preference> { Preference.Animals, Preference.Sport }
                });
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }
    }
}
