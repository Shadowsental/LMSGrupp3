using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LMSGrupp3.Models.Entities
{
	public class User : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string FullName => $"{FirstName} {LastName}";

	//NavProp
	public Course Course { get; set; }
		public ICollection<Document> Documents { get; set; }

		//FK
		public int? CourseId { get; set; }


	}
}
