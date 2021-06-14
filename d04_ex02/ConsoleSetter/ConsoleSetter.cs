using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using d04_ex02.Attributes;
using System.Linq;
using System.ComponentModel;

namespace d04_ex02
{
	class ConsoleSetter
	{
		public static void SetValues<T>(T input) where T : class {
			Type t = typeof(T);
			Console.WriteLine($"Let's set {t.Name}!");
			foreach(var p in t.GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
				var query =
					from attr in Attribute.GetCustomAttributes(p)
					where attr is NoDisplayAttribute
					select attr;
				if (query.Any())
					continue;
				var descrq =
					from attr in Attribute.GetCustomAttributes(p)
					where attr is DescriptionAttribute
					select attr;
				var descr = (descrq.Any() ? (descrq.First() as DescriptionAttribute).Description : p.Name);
				Console.WriteLine($"Set {descr}:");
				string val = Console.ReadLine();
				var defvalq =
					from attr in Attribute.GetCustomAttributes(p)
					where attr is DefaultValueAttribute
					select attr;
				var defval = (defvalq.Any() ? (defvalq.First() as DefaultValueAttribute).Value : null);
				object o = Convert.ChangeType(val.Length > 0 ? val : defval, p.PropertyType);
				p.SetValue(input, o);
			}
			Console.WriteLine("We've set our instance!");
		}
	}
}
