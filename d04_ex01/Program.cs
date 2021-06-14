using Microsoft.AspNetCore.Http;
using System;
using System.Reflection;

namespace d04_ex01
{
	class Program
	{
		static void Main(string[] args) {
			var context = new DefaultHttpContext();
			Console.WriteLine($"Old Response value: {context.Response}");
			var type = context.GetType();
			var fieldInfo = type.GetField("_response", BindingFlags.NonPublic | BindingFlags.Instance);
			fieldInfo.SetValue(context, null);
			Console.WriteLine($"New Response value: {context.Response}");
		}
	}
}
