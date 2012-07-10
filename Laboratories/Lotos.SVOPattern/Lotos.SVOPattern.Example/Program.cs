using System;
using System.Collections.Generic;
using System.Text;

namespace Lotos.SVOPattern.Example
{
	class Program
	{
		static void Main(string[] args)
		{
			SubjectObject o = new SubjectObject();
			SVO s =o.GetProperty("name").IsEqualsTo(2)
				.And(o.GetProperty("age").IsEqualsTo(23));
			Console.WriteLine(s.ToString());
			Console.ReadLine();
		}
	}
}
