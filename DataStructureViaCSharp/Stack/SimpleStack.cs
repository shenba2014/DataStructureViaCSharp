using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.Stack
{
	public class SimpleStack<TData>
	{
		private readonly TData[] _values;

		private int _count;

		public SimpleStack(int capacity)
		{
			_values = new TData[capacity];
		}

		public int Count => _count;

		public bool Push(TData element)
		{
			if (_count + 1 > _values.Length)
				return false;

			_values[_count++] = element;
			return true;
		}

		public TData Pop()
		{
			if (_count == 0)
				return default(TData);

			var value = _values[_count - 1];
			_values[_count - 1] = default(TData);
			_count--;

			return value;
		}
	}
}
