using System;

namespace DataStructureViaCSharp.Arrays
{
	internal class Delete : IExample
	{
		public string Name => "ArrayDelete";

		public void Run()
		{
			var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			Console.WriteLine("Here is the array values");
			Console.WriteLine(string.Join(",", values));

			var index = CommandLineHelper.ReadNumberValue("Please input a position index where to delete a number");
			index = index - 1;
			while (index > values.Length - 1 || index < 0)
			{
				index = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");
			}

			values = values.Delete(index);

			Console.WriteLine($"After delete a number at index {index}, here is the new array values");
			Console.WriteLine(string.Join(",", values));
		}
	}
}
