using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMSGrupp3.Models.Entities
{
    public class Module
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Module Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} must be specified")]
        [Display(Name = "Startdate")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "{0} must be specified")]
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime EndTime { get; set; }

        [Display(Name = "Activity")]
        public ICollection<ActivityModel> ActivityModels { get; set; }

        public ICollection<Document> Documents { get; set; }
        // Navigational reference 
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}