using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DataStructureViaCSharp.Arrays;

namespace DataStructureViaCSharp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Examples");
			var exampleDictionary = LoadExamples();
			foreach (var example in exampleDictionary)
			{
				Console.WriteLine($"{example.Key}.{example.Value.Name}");
			}
			var number = CommandLineHelper.ReadNumberValue("Please input a number to run");
			while (!exampleDictionary.ContainsKey(number))
			{
				number = CommandLineHelper.ReadNumberValue("Please input an exists number");
			}
			Console.WriteLine("-----------------------------------");
			var exampleToRun = exampleDictionary[number];
			Console.WriteLine($"Example {exampleToRun.Name} is selected");
			exampleToRun.Run();
		}

		private static IDictionary<int, IExample> LoadExamples()
		{
			var exampleTypes
				= Assembly.GetCallingAssembly().GetTypes()
					.Where(type => typeof(IExample).IsAssignableFrom(type) && !type.IsInterface);
			var index = 0;
			return
				exampleTypes.Select(exampleType => Activator.CreateInstance(exampleType) as IExample)
					.ToDictionary(exampleInstance => index++);
		}
	}
}
