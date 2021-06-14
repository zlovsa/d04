using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d04_ex02.Models
{
	public class IdentityRole
	{
		public IdentityRole() {
		}

		public string Name { get; set; }
		public string Description { get; set; }

		public override string ToString()
		   => $"{Name}, {Description}";
	}

}
