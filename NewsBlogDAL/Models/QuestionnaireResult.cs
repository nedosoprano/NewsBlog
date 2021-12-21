using NewsBlogDAL.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsBlogDAL.Models
{
    /// <summary>
    /// Questionnaire result
    /// </summary>
    public class QuestionnaireResult
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// participated in the questionnaire person first name
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// participated in the questionnaire person last name
        /// </summary>
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        /// <summary>
        /// participated in the questionnaire person sex
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// participated in the questionnaire person preferences
        /// </summary>
        public List<Preference> Preferences { get; set; }
    }
}