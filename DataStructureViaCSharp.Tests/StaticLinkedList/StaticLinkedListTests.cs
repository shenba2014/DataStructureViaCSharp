using System;
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
			var node = _linkedList.Find(2);
			Assert.NotNull(node);
			Assert.Equal(2, node.Data);
		}

		[Fact]
		public void ShouldInsertNode()
		{
			var index = 3;
			var data = 101;
			_linkedList.Insert(index, data);
			var node = _linkedList.Find(index);
			Assert.NotNull(node);
			Assert.Equal(data, node.Data);
			Assert.Equal(11, _linkedList.Length);
		}

		[Fact]
		public void ShouldDeleteNode()
		{
			var index = 2;
			_linkedList.Delete(index);
			var node = _linkedList.Find(index);
			Assert.NotNull(node);
			Assert.Equal(3, node.Data);
			Assert.Equal(9, _linkedList.Length);
		}

		[Fact]
		public void ShouldConvertToOriginalArray()
		{
			var array = _linkedList.ToArray();
			for (var i = 0; i < array.Length; i++)
				Assert.Equal(_values[i], array[i]);
		}

		public void Dispose()
		{
			_linkedList = null;
		}
	}
}
