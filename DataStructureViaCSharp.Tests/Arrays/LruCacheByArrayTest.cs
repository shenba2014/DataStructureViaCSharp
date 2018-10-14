using DataStructureViaCSharp.Arrays;
using Xunit;

namespace DataStructureViaCSharp.Tests.Arrays
{
	public class LruCacheByArrayTest
	{
		[Fact]
		public void ShouldAddElementToHead()
		{
			var lruCache = new LruCacheByArray(10);
			lruCache.Add("key1",  2);
			lruCache.Add("key2",  3);

			Assert.Equal(3, lruCache.GetByIndex(0));
			Assert.Equal(2, lruCache.GetByIndex(1));
		}

		[Fact]
		public void ShouldRemoveElementAtEndWhenCacheIsFull()
		{
			var lruCache = new LruCacheByArray(3);
			lruCache.Add("key1", 10);
			lruCache.Add("key2", 11);
			lruCache.Add("key3", 19);
			lruCache.Add("key4", 20);

			Assert.Equal(20, lruCache.GetByIndex(0));
			Assert.Equal(19, lruCache.GetByIndex(1));
			Assert.Equal(11, lruCache.GetByIndex(2));
			Assert.Null(lruCache.GetByIndex(3));
		}

		[Fact]
		public void ShouldAddElementToHeadAfterAccessingIt()
		{
			var lruCache = new LruCacheByArray(4);
			lruCache.Add("key1", 10);
			lruCache.Add("key2", 11);
			lruCache.Add("key3", 19);
			lruCache.Add("key4", 20);

			var value = lruCache.Get("key2");
			Assert.Equal(11, value);

			Assert.Equal(11, lruCache.GetByIndex(0));
			Assert.Equal(20, lruCache.GetByIndex(1));
			Assert.Equal(19, lruCache.GetByIndex(2));
			Assert.Equal(10, lruCache.GetByIndex(3));
		}
	}
}
