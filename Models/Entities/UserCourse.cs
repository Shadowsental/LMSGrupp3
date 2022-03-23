using LMSGrupp3.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSGrupp3.Models
{
    public class UserCourse
    {

        [Key]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
