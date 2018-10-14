using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.SingleLinkedList;
using Xunit;

namespace DataStructureViaCSharp.Tests.SingleLinkedList
{
	public class LruCacheByLinkedListTest
	{
		[Fact]
		public void ShouldAddElementToHead()
		{
			var lruCache = new LruCacheByLinkedList(10);
			lruCache.Add(10);
			lruCache.Add(11);

			Assert.Equal(11, lruCache.GetByIndex(1));
			Assert.Equal(10, lruCache.GetByIndex(2));
		}

		[Fact]
		public void ShouldRemoveElementAtEndWhenCacheIsFull()
		{
			var lruCache = new LruCacheByLinkedList(3);
			lruCache.Add(10);
			lruCache.Add(11);
			lruCache.Add(19);
			lruCache.Add(20);

			Assert.Equal(20, lruCache.GetByIndex(1));
			Assert.Equal(19, lruCache.GetByIndex(2));
			Assert.Equal(11, lruCache.GetByIndex(3));
			Assert.False(lruCache.GetByIndex(4).HasValue);
		}

		[Fact]
		public void ShouldAddElementToHeadAfterAccessingIt()
		{
			var lruCache = new LruCacheByLinkedList(4);
			lruCache.Add(10);
			lruCache.Add(11);
			lruCache.Add(19);
			lruCache.Add(20);

			var value = lruCache.GetByValue(11);
			Assert.Equal(11, value);

			Assert.Equal(11, lruCache.GetByIndex(1));
			Assert.Equal(20, lruCache.GetByIndex(2));
			Assert.Equal(19, lruCache.GetByIndex(3));
			Assert.Equal(10, lruCache.GetByIndex(4));
		}
	}
}
