using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMSGrupp3.Models.Entities
{
	public class ActivityModel
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Display(Name = "Activity Type")]
		[ForeignKey("ActivityTypeId")]
		public int? ActivityTypeId { get; set; }

		[Display(Name = "Activity Type")]
		public ActivityType ActivityType { get; set; }

		[ForeignKey("ModuleId")]
		public int ModuleId { get; set; }

		[Required]
		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required(ErrorMessage = "{0} must be specified")]
		[Display(Name = "Startdate")]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessage = "{0} måste anges")]
		[Display(Name = "Slutdatum")]
		public DateTime StopDate { get; set; }

		[Required]
		[Display(Name = "Desciption of Activity")]
		public string Description { get; set; }


	}
}
