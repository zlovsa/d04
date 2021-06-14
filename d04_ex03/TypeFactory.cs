using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d04_ex03
{
	class TypeFactory
	{
		public static T CreateWithConstructor<T>() where T : class{
			Type type = typeof(T);
			var cinfo = type.GetConstructor(Type.EmptyTypes);
			return (T)cinfo.Invoke(null);
		}

		public static T CreateWithActivator<T>() where T : class {
			Type type = typeof(T);
			return (T)Activator.CreateInstance(type);
		}

		public static T CreateConsoleSetter<T>() where T : class {
			Type type = typeof(T);
			Console.WriteLine(type.FullName);
			var cinfos = type.GetConstructors();
			var parConstrInfos = cinfos.Where(c => c.GetParameters().Length > 0);
			if (!parConstrInfos.Any()) {
				Console.WriteLine("No constructors with parameters!");
				return (T)Activator.CreateInstance(type);
			}
			var cinfo = parConstrInfos.First();
			var pars=new List<object>();
			foreach(var pi in cinfo.GetParameters()) {
				Console.WriteLine($"Set {pi.Name}:");
				var str = Console.ReadLine();
				var o = Convert.ChangeType(str, pi.ParameterType);
				pars.Add(o);
				Console.WriteLine($"{pi.Name} set: {o}");
			}
			return (T)cinfo.Invoke(pars.ToArray());
		}

	}
}
