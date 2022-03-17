using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMSGrupp3.Models.Entities
{
	public class ActivityType
	{
		public int Id { get; set; }
		public string Name { get; set; }

		//NavProp
		public ICollection<Activity> Activities { get; set; }

	}
}
