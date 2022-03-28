using System;
using System.ComponentModel.DataAnnotations;

namespace LMSGrupp3.Models.ViewModels
{
    public class DocumentFileViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string FileName { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserId { get; set; }
        public int? CourseId { get; set; }
        public int? ModuleId { get; set; }
        public int? ActivityId { get; set; }

        public LMSFormFile LMSFormFile { get; set; }

    }
}
