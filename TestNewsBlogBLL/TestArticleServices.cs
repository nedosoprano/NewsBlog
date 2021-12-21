using Moq;
using NewsBlogBLL.Services;
using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace TestNewsBlog
{
    public class TestsArticleService
    {
        static Article article;
        static Mock<IRepository<Article>> mockArticles;

        [SetUp]
        public void Setup()
        {
            article = new Article
            {
                Id = 1,
                Title = "Title",
                Text = "The most compelling article!"
            };

            mockArticles = new Mock<IRepository<Article>>();
            mockArticles.Setup(frepo => frepo.CreateAsync(It.IsAny<Article>())).Returns(Task.FromResult(article));
            mockArticles.Setup(frepo => frepo.UpdateAsync(It.IsAny<Article>())).Returns(Task.FromResult(true));
        }

        [Test]
        public void CreateAsync_CorrectValues_ReturnArticle()
        {
            IService<Article> articleservices = new ArticleService(mockArticles.Object);

            Task<Article> newArticle = articleservices.CreateAsync(new Article
            {
                Id = 1,
                Title = "Title",
                Text = "The most compelling article!"
            });

            Assert.AreEqual(newArticle.Result, article);
        }

        [Test]
        public void CreateAsync_ArgumentIsNull_ThrowArgumentException()
        {
            IService<Article> articleervices = new ArticleService(mockArticles.Object);
            var expectedTypeError = typeof(ArgumentException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await articleervices.CreateAsync(null);
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }

        [Test]
        public void CreateAsync_ArgumentFieldsIsNull_ThrowArgumentException()
        {
            IService<Article> articleervices = new ArticleService(mockArticles.Object);
            var expectedTypeError = typeof(ArgumentException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await articleervices.CreateAsync(new Article());
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }

        [Test]
        public void UpdateAsync_CorrectValues_ReturnArticle()
        {
            IService<Article> articleservices = new ArticleService(mockArticles.Object);
            var expectedResult = true;

            Task<bool> result = articleservices.UpdateAsync(new Article
            {
                Id = 1,
                Title = "Title",
                Text = "The most compelling article!"
            });

            Assert.AreEqual(result.Result, expectedResult);
        }

        [Test]
        public void UpdateAsync_ArgumentIsNull_ThrowArgumentException()
        {
            IService<Article> articleervices = new ArticleService(mockArticles.Object);
            var expectedTypeError = typeof(ArgumentException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await articleervices.UpdateAsync(null);
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }

        [Test]
        public void UpdateAsync_ArgumentFieldsIsNull_ThrowArgumentException()
        {
            IService<Article> articleervices = new ArticleService(mockArticles.Object);
            var expectedTypeError = typeof(ArgumentException);

            Exception ex = Assert.CatchAsync(async () =>
            {
                await articleervices.UpdateAsync(new Article());
            });

            Assert.AreEqual(expectedTypeError, ex.GetType());
        }
    }
}