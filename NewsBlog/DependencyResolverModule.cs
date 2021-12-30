using NewsBlogDAL.Models;
using NewsBlogDAL.Repositories;
using NewsBlogBLL.Services;
using Ninject.Modules;

namespace NewsBlog
{
    /// <summary>
    /// Dependency Resolver Module
    /// </summary>
    public class DependencyResolverModule : NinjectModule
    {
        /// <summary>
        /// Creation Dependency Injections
        /// </summary>
        public override void Load()
        {
            Bind<IService<Article>>().To<ArticleService>();
            Bind<IRepository<Article>>().To<ArticleRepository>();

            Bind<IService<Feedback>>().To<FeedbackService>();
            Bind<IRepository<Feedback>>().To<FeedbackRepository>();

            Bind<IService<QuestionnaireResult>>().To<QuestionnaireResultService>();
            Bind<IRepository<QuestionnaireResult>>().To<QuestionnaireResultRepository>();

            Bind<IUserService>().To<UserService>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}