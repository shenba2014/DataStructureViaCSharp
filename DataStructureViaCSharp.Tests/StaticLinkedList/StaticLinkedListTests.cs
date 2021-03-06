﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.SingleLinkedList;
using Xunit;

namespace DataStructureViaCSharp.Tests.StaticLinkedList
{
	public class StaticLinkedListTests
	{
		private readonly int[] _values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
		private DataStructureViaCSharp.StaticLinkedList.StaticLinkedList _linkedList;

		public StaticLinkedListTests()
		{
			_linkedList = new DataStructureViaCSharp.StaticLinkedList.StaticLinkedList(_values);
		}

		[Fact]
		public void ShouldFindNode()
		{
			var value = _linkedList.FindValueByIndex(2);
			Assert.NotNull(value);
			Assert.Equal(2, value);
		}

		[Fact]
		public void ShouldInsertNode()
		{
			var index = 3;
			var data = 101;
			_linkedList.Insert(index, data);
			var value = _linkedList.FindValueByIndex(index);
			Assert.NotNull(value);
			Assert.Equal(data, value);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldAppendNode()
		{
			const int data = 101;
			_linkedList.Append(data);
			var value = _linkedList.FindValueByIndex(_linkedList.Length);
			Assert.NotNull(value);
			Assert.Equal(data, value);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldDeleteNode()
		{
			var index = 2;
			_linkedList.DeleteByIndex(index);
			var value = _linkedList.FindValueByIndex(index);
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
			Assert.Equal(0, _linkedList.ToArray().Length);
		}

		public void Dispose()
		{
			_linkedList = null;
		}
	}
}
