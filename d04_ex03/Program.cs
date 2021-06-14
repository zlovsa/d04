using d04_ex03.Models;
using System;

namespace d04_ex03
{
	class Program
	{
		static void Main(string[] args) {
			test<IdentityUser>();
			test<IdentityRole>();
			Console.WriteLine();
			var user = TypeFactory.CreateConsoleSetter<IdentityUser>();
			Console.WriteLine(user);
		}

		static void test<T>() where T : class {
			var user1 = TypeFactory.CreateWithConstructor<T>();
			var user2 = TypeFactory.CreateWithActivator<T>();
			Console.WriteLine($"{typeof(T).FullName}");
			Console.WriteLine($"user1 {(user1 == user2 ? '=' : '!')}= user2");
		}
	}
}
