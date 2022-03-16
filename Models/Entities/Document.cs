using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace LMSGrupp3.Models.Entities
{
	public class Document
	{
		public int Id { get; set; }
		public string Name { get; set; }	
		public string Description { get; set; }
		public DateTime UploadTime { get; set; }
		public bool? IsCompleted { get; set; }

		//NavProp
		public Course Course { get; set; }
		public Module Module { get; set; }
		public Activity Activity { get; set; }
		public User User { get; set; }

		//FK
		public int? CourseId { get; set; }
		public int? ModuleId { get; set; }
		public int? ActivityId { get; set; }
		public string UserId { get; set; }


	}
}
