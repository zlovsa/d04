using Microsoft.AspNetCore.Http;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace d04_ex00
{
	class Program
	{
		static void Main() {
			var t = typeof(DefaultHttpContext);
			Console.WriteLine(
				$@"Type: {t.FullName}
				Assembly: {t.Assembly.FullName}
				Based on: {t.BaseType.FullName}

				Fields:
				{string.Join(Environment.NewLine, t.GetFields(
					BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance
				).Select(f => $"{f.FieldType} {f.Name}"))}

				Properties:
				{string.Join(Environment.NewLine, t.GetProperties(
					BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance
				).Select(p => $"{p.PropertyType} {p.Name}"))}

				Methods:
				{string.Join(Environment.NewLine, t.GetMethods(
					BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance
				).Select(m => $@"{m.ReturnType.Name} {m.Name} ({
					string.Join(", ", m.GetParameters().Select(par => $"{par.ParameterType.Name} {par.Name}"))})"))}"
			.Replace("\t",""));
		}
	}
}
