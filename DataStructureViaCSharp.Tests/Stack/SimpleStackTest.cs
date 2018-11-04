using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.Stack;
using Xunit;

namespace DataStructureViaCSharp.Tests.Stack
{
	public class SimpleStackTest
	{
		[Fact]
		public void ShouldOutputElementInReverseOrder()
		{
			var stack = new SimpleStack<int>(10);
			stack.Push(1);
			stack.Push(2);

			var value = stack.Pop();
			Assert.Equal(2, value);

			value = stack.Pop();
			Assert.Equal(1, value);
		}

		[Fact]
		public void ShouldPushFailedWhenStackIsFull()
		{
			var stack = new SimpleStack<int>(2);
			stack.Push(1);
			stack.Push(2);
			var result = stack.Push(3);

			Assert.False(result);
		}

		[Fact]
		public void ShouldPopDefaultValueWhenStackIsEmpty()
		{
			var stack = new SimpleStack<object>(2);
			var result = stack.Pop();

			Assert.Null(result);
		}
	}
}
