using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSGrupp3.Models.Entities
{
    public class UserCourse
    {
        //[Key]
        //public int Id { get; set; }

    //    [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
