using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.StaticLinkedList
{
	public class Find : IExample
	{
		public string Name => "StaticLinkedListFind";

		public void Run()
		{
			var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var linkedList = new StaticLinkedList(values);
			Console.WriteLine("Here is the values in linked list");
			Console.WriteLine(string.Join(",", values));
			var index = CommandLineHelper.ReadNumberValue("Please input a position index to find a number");
			while (index < 1 || index > linkedList.Length)
				index = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");
			var item = linkedList.Find(index);
			Console.WriteLine(item != null ? $"{item.Data} found at postion {index}" : "no number is found");
		}
	}
}
