using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LMSGrupp3.Models.Entities
{
    public class Document
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        [Display(Name = "Timestamp")]
        public DateTime Timestamp { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Course")]
        public int? CourseId { get; set; }

        [Display(Name = "Module")]
        public int? ModuleId { get; set; }

        [Display(Name = "Activity")]
        public int? ActivityId { get; set; }
    }
}
