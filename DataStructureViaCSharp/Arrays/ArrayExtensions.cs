using System;

namespace DataStructureViaCSharp.Arrays
{
	public static class ArrayExtensions
	{
		public static int[] Delete(this int[] values, int index)
		{
			for (var i = index; i < values.Length - 1; i++)
				values[i] = values[i + 1];
			values[values.Length - 1] = 0;
			Array.Resize(ref values, values.Length - 1);
			return values;
		}

		public static int[] Insert(this int[] values, int index, int data)
		{
			Array.Resize(ref values, values.Length + 1);
			for (var i = values.Length - 1; i > index; i--)
				values[i] = values[i - 1];
			values[index] = data;
			return values;
		}
	}
}
