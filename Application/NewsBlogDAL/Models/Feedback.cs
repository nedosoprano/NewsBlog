using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsBlogDAL.Models
{
    /// <summary>
    /// Feedback
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Fedback autor
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string AuthorName { get; set; }

        /// <summary>
        /// Feedback text
        /// </summary>
        [Required]
        public string ReviewText { get; set; }

        /// <summary>
        /// Feedback creation date
        /// </summary>
        public DateTime Date { get; set; }

        public Feedback()
        {
            Date = DateTime.Today;
        }
    }
}