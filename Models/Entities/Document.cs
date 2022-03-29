using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
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

        public string FilePath { get; set; }
        public bool? IsFinished { get; set; }

        // Foreign Keys
        public string UserId { get; set; }
        public int? CourseId { get; set; }
        public int? ModuleId { get; set; }
        public int? ActivityModelId { get; set; }

        // Navigation Properties
        [DisplayName("Uploader")]
        public User AppUser { get; set; }
        public Course Course { get; set; }
        public Module Module { get; set; }
        public ActivityModel ActivityModel { get; set; }

    }
}
