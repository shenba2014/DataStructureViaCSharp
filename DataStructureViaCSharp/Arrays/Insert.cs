using System;

namespace DataStructureViaCSharp.Arrays
{
	class Insert : IExample
	{
		public string Name => "ArrayInsert";

		public void Run()
		{
			var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			Console.WriteLine("Here is the array values");
			Console.WriteLine(string.Join(",", values));

			var insertIndex = CommandLineHelper.ReadNumberValue("Please input the position index(zero based) where to insert a new number");
			while (insertIndex > values.Length - 1 || insertIndex < 0)
			{
				insertIndex = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");
			}

			var insertValue = CommandLineHelper.ReadNumberValue("Please input a value to insert");

			Array.Resize(ref values, values.Length + 1);
			for (var i = values.Length - 1; i > insertIndex; i--)
			{
				values[i] = values[i - 1];
			}
			values[insertIndex] = insertValue;

			Console.WriteLine("after insert a new number, here is the new array values");
			Console.WriteLine(string.Join(",", values));
		}
	}
}
