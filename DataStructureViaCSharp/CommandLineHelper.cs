using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp
{
	class CommandLineHelper
	{
		internal static int ReadNumberValue(string message = null)
		{
			if (!string.IsNullOrWhiteSpace(message))
			{
				Console.WriteLine(message);
			}
			var inputValue = Console.ReadLine();
			int number;
			while (!int.TryParse(inputValue, out number))
			{
				Console.WriteLine("please input a number");
				inputValue = Console.ReadLine();
			}
			return number;
		}
	}
}
