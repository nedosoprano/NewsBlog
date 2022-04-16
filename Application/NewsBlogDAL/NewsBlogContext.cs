using NewsBlogDAL.Models;
using System.Data.Entity;

namespace NewsBlogDAL
{
    /// <summary>
    /// Connection with database
    /// </summary>
    public class NewsBlogContext : DbContext
    {
        /// <summary>
        /// Database Articles
        /// </summary>
        public DbSet<Article> Articles { get; set; }

        /// <summary>
        /// Database Feedbacks
        /// </summary>
        public DbSet<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Database QuestionnaireResults
        /// </summary>
        public DbSet<QuestionnaireResult> QuestionnaireResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}