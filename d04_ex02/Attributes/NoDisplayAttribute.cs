using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d04_ex02.Attributes
{
	[System.AttributeUsage(System.AttributeTargets.Property, AllowMultiple = false)]
	class NoDisplayAttribute : Attribute
	{

	}
}
