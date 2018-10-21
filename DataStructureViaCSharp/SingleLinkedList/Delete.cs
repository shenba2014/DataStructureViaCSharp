using System;

namespace DataStructureViaCSharp.SingleLinkedList
{
	internal class Delete : IExample
	{
		public string Name => "SingleLinkedListDelete";

		public void Run()
		{
			var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var linkedList = new SingleLinkedList<int>(values);
			Console.WriteLine("Here is the values");
			Console.WriteLine(string.Join(",", values));

			var index = CommandLineHelper.ReadNumberValue("Please input a position index where to delete a number");
			while (index < 1 || index > linkedList.Length)
				index = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");

			linkedList.DeleteNodeByIndex(index);

			Console.WriteLine($"After delete a number at index {index}, here is the new values");
			Console.WriteLine(string.Join(",", linkedList.ToArray()));
		}
	}
}
