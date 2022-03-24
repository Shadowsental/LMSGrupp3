using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LMSGrupp3.Models.Entities
{
	public class ActivityModel
	{
		public int Id { get; set; }

		[ForeignKey("ActivityTypeId")]
		public int? ActivityTypeId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }

		public DateTime StopDate { get; set; }


		//NavProp
		public Module Module { get; set; }
		public ActivityType ActivityType { get; set; }
		public ICollection<Document> Documents { get; set;}

		//FK

		
		
		[ForeignKey("ModuleId")]
		public int ModuleId { get; set; }


	}
}
