using System;

namespace DataStructureViaCSharp.SingleLinkedList
{
	internal class Insert : IExample
	{
		public string Name => "SingleLinkedListInsert";

		public void Run()
		{
			var values = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
			var linkedList = new SingleLinkedList(values);
			Console.WriteLine("Here is the values");
			Console.WriteLine(string.Join(",", values));

			var index = CommandLineHelper.ReadNumberValue("Please input a position index where to insert a new number");
			while (index < 1 || index > linkedList.Length)
				index = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");

			var data = CommandLineHelper.ReadNumberValue("Please input a value to insert");

			linkedList.Insert(index, data);

			Console.WriteLine("After insert a new number, here is the new values");
			Console.WriteLine(string.Join(",", linkedList.ToArray()));
		}
	}
}
