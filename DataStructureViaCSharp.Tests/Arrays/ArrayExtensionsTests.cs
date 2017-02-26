using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.Arrays;
using Xunit;

namespace DataStructureViaCSharp.Tests.Arrays
{
	public class ArrayExtensionsTests : IDisposable
	{
		private int[] _values;

		public ArrayExtensionsTests()
		{
			_values =new []{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		}

		[Fact]
		public void ShouldDeleteElement()
		{
			var newValues = _values.Delete(1);
			Assert.Equal(9, newValues.Length);
			Assert.Equal(newValues[1], 3);
		}

		[Fact]
		public void ShouldInsertElement()
		{
			var newValues = _values.Insert(1, 101);
			Assert.Equal(11, newValues.Length);
			Assert.Equal(newValues[1], 101);
		}

		public void Dispose()
		{
			_values = null;
		}
	}
}
