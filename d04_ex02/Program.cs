using d04_ex02.Models;
using d04_ex02.Attributes;
using d04_ex02;
using System;

namespace d04_ex02
{
	class Program
	{
		static void Main(string[] args) {
			try {
				var identityUser = new IdentityUser();
				ConsoleSetter.SetValues(identityUser);
				Console.WriteLine($"{identityUser}");
				var identityRole = new IdentityRole();
				ConsoleSetter.SetValues(identityRole);
				Console.WriteLine($"{identityRole}");
			} catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
	}
}
