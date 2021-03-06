﻿using System;

namespace DataStructureViaCSharp.Arrays
{
	internal class Insert : IExample
	{
		public string Name => "ArrayInsert";

		public void Run()
		{
			var values = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			Console.WriteLine("Here is the array values");
			Console.WriteLine(string.Join(",", values));

			var index = CommandLineHelper.ReadNumberValue("Please input a position index where to insert a new number");
			index = index - 1;
			while (index > values.Length - 1 || index < 0)
			{
				index = CommandLineHelper.ReadNumberValue("Index out of range, please input a valid index");
			}
			
			var data = CommandLineHelper.ReadNumberValue("Please input a value to insert");

			values = values.Insert(index, data);

			Console.WriteLine("After insert a new number, here is the new array values");
			Console.WriteLine(string.Join(",", values));
		}
	}
}
