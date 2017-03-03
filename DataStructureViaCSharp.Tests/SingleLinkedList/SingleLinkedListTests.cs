using System;
using DataStructureViaCSharp.Common;
using DataStructureViaCSharp.SingleLinkedList;
using Xunit;

namespace DataStructureViaCSharp.Tests.SingleLinkedList
{
	public class SingleLinkedListTests : IDisposable
	{
		private readonly int[] _values = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		private DataStructureViaCSharp.SingleLinkedList.SingleLinkedList _linkedList;

		public SingleLinkedListTests()
		{
			_linkedList = new DataStructureViaCSharp.SingleLinkedList.SingleLinkedList(_values);
		}

		[Fact]
		public void ShouldMatchArrayValues()
		{
			Assert.Equal(10, _linkedList.Length);
			LinkedListNode node = _linkedList.Head;
			var i = 0;
			while (node.Next != null)
			{
				Assert.Equal(_values[i++], node.Next.Data);
				node = node.Next;
			}
			Assert.Equal(10, i);
		}

		[Fact]
		public void ShouldFindNode()
		{
			var value = _linkedList.Find(2);
			Assert.NotNull(value);
			Assert.Equal(2, value);
		}

		[Fact]
		public void ShouldInsertNode()
		{
			var index = 3;
			var data = 101;
			_linkedList.Insert(index, data);
			var value = _linkedList.Find(index);
			Assert.NotNull(value);
			Assert.Equal(data, value);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldAppendNode()
		{
			const int data = 101;
			_linkedList.Append(data);
			var value = _linkedList.Find(_linkedList.Length);
			Assert.NotNull(value);
			Assert.Equal(data, value);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldDeleteNode()
		{
			var index = 2;
			_linkedList.Delete(index);
			var value = _linkedList.Find(index);
			Assert.NotNull(value);
			Assert.Equal(3, value);
			Assert.Equal(9, _linkedList.Length);
		}

		[Fact]
		public void ShouldConvertToOriginalArray()
		{
			var array = _linkedList.ToArray();
			for (var i = 0; i < array.Length; i++)
				Assert.Equal(_values[i], array[i]);
		}

		[Fact]
		public void ShouldClearNode()
		{
			_linkedList.Clear();
			Assert.Equal(0, _linkedList.Length);
			Assert.Null(_linkedList.Head.Next);
		}

		public void Dispose()
		{
			_linkedList.Clear();
			_linkedList = null;
		}
	}
}
