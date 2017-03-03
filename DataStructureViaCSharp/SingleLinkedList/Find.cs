using System;

namespace DataStructureViaCSharp.SingleLinkedList
{
	internal class Find : IExample
	{
		public string Name => "SingleLinkedListFind";

		public void Run()
		{
			var values = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
			var linkedList = new SingleLinkedList(values);
			Console.WriteLine("Here is the values in linked list");
			Console.WriteLine(string.Join(",", values));
			var index = CommandLineHelper.ReadNumberValue("Please input a position index to find a number");
			while (index < 1 || index > linkedList.Length)
				index = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");
			var value = linkedList.Find(index);
			Console.WriteLine(value != null ? $"{value} found at postion {index}" : "no number is found");
		}
	}
}
