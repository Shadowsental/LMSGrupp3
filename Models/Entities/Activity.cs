using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.Entities
{
	public class Activity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		//NavProp
		public Module Module { get; set; }
		public ActivityType ActivityType { get; set; }
		public ICollection<Document> Documents { get; set;}

		//FK

		public int ActivityTypeId { get; set; }
		public int ModuleId { get; set; }


	}
}
