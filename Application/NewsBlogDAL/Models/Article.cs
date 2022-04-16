using NewsBlogDAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsBlogDAL.Models
{
    /// <summary>
    /// Article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Article title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Article text
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Article creation date
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Article tag
        /// </summary>
        public Preference Tag { get; set; }

        public Article()
        {
            CreationDate = DateTime.Today;
        }
    }
}