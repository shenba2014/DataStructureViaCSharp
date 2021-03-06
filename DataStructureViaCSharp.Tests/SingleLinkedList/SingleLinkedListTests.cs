﻿using System;
using DataStructureViaCSharp.SingleLinkedList;
using Xunit;

namespace DataStructureViaCSharp.Tests.SingleLinkedList
{
	public class SingleLinkedListTests : IDisposable
	{
		private readonly int[] _values = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		private SingleLinkedList<int> _linkedList;

		public SingleLinkedListTests()
		{
			_linkedList = new SingleLinkedList<int>(_values);
		}

		[Fact]
		public void ShouldMatchArrayValues()
		{
			Assert.Equal(10, _linkedList.Length);
			LinkedListNode<int> node = _linkedList.Head;
			var i = 0;
			while (node.Next != null)
			{
				Assert.Equal(_values[i++], node.Next.Data);
				node = node.Next;
			}
			Assert.Equal(10, i);
		}

		[Fact]
		public void ShouldFindNodeByIndex()
		{
			var node = _linkedList.FindNodeByIndex(2);
			Assert.Equal(2, node.Data);
			Assert.Equal(3, node.Next.Data);
		}

		[Fact]
		public void ShouldFindNodeByValue()
		{
			_linkedList = new SingleLinkedList<int>(new[] {3, 5, 7, 8});
			var node = _linkedList.FindNodeByValue(7);
			Assert.Equal(7, node.Data);
			Assert.Equal(8, node.Next.Data);
		}

		[Fact]
		public void ShouldFindMiddleNodeWithEvenCount()
		{
			_linkedList = new SingleLinkedList<int>(new[] { 3, 5, 7, 8 });
			var middleNode = _linkedList.FindMiddleNode();
			Assert.Equal(5, middleNode.Data);
		}

		[Fact]
		public void ShouldFindMiddleNodeWithOddCount()
		{
			_linkedList = new SingleLinkedList<int>(new[] { 3, 5, 4, 7, 8 });
			var middleNode = _linkedList.FindMiddleNode();
			Assert.Equal(4, middleNode.Data);
		}

		[Fact]
		public void ShouldInsertNode()
		{
			var index = 3;
			var data = 101;
			_linkedList.Insert(index, data);
			var value = _linkedList.FindNodeByIndex(index).Data;
			Assert.Equal(data, value);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldAppendNode()
		{
			const int data = 101;
			_linkedList.Append(data);
			var value = _linkedList.FindNodeByIndex(_linkedList.Length).Data;
			Assert.Equal(data, value);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldDeleteNode()
		{
			var index = 2;
			_linkedList.DeleteNodeByIndex(index);
			var value = _linkedList.FindNodeByIndex(index).Data;
			Assert.Equal(3, value);
			Assert.Equal(9, _linkedList.Length);
		}

		[Fact]
		public void ShouldDeleteNodeByReverseIndex()
		{
			var index = 2;
			_linkedList.DeleteNodeByReverseIndex(index);
			var value = _linkedList.FindNodeByIndex(9).Data;
			Assert.Equal(10, value);
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

		[Fact]
		public void ShouldReverseLinkedList()
		{
			_linkedList.Reverse();
			var reversedArray = _linkedList.ToArray();
			var length = _values.Length;
			for (var i = 0; i < length; i++)
			{
				Assert.Equal(reversedArray[i], _values[length - i - 1]);
			}
		}

		[Fact]
		public void ShouldMergeTwoLinkedListByImplement1()
		{
			var linkedList1 = new SingleLinkedList<int>(new[]{1, 2, 4});
			var linkedList2 = new SingleLinkedList<int>(new[]{1, 3, 4});
			var mergedLinkedNodeHead = LinkedListMerger.MergeImplement1(linkedList1.Head.Next, linkedList2.Head.Next);

			var expectedValues = new[] {1, 1, 2, 3, 4, 4};
			var node = mergedLinkedNodeHead.Next;
			for (int i = 0; i < expectedValues.Length; i++)
			{
				Assert.Equal(expectedValues[i], node.Data);
				node = node.Next;
			}
		}

		[Fact]
		public void ShouldMergeTwoLinkedListByImplement2()
		{
			var linkedList1 = new SingleLinkedList<int>(new[] { 1, 2, 4 });
			var linkedList2 = new SingleLinkedList<int>(new[] { 1, 3, 4 });
			var mergedLinkedNodeHead = LinkedListMerger.MergeImplement2(linkedList1.Head.Next, linkedList2.Head.Next);

			var expectedValues = new[] { 1, 1, 2, 3, 4, 4 };
			var node = mergedLinkedNodeHead.Next;
			for (int i = 0; i < expectedValues.Length; i++)
			{
				Assert.Equal(expectedValues[i], node.Data);
				node = node.Next;
			}
		}

		public void Dispose()
		{
			_linkedList.Clear();
			_linkedList = null;
		}
	}
}
