using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.Arrays
{
	public class LruCacheItem
	{
		public string Key { get; set; }

		public object Value { get; set; }
	}

	public class LruCacheByArray
	{
		private readonly int _maxCacheCount;

		private readonly LruCacheItem[] _cacheItems;

		private int _cacheCount;

		private readonly Dictionary<string, int> _keyIndexDictionary;

		public LruCacheByArray(int maxCacheCount)
		{
			_maxCacheCount = maxCacheCount;
			_cacheItems = new LruCacheItem[_maxCacheCount];
			_keyIndexDictionary = new Dictionary<string, int>(_maxCacheCount);
		}

		public void Add(string key, object value)
		{
			var index = _cacheCount;
			if (_cacheCount + 1 > _maxCacheCount)
			{
				index = _maxCacheCount - 1;
			}

			for (var i = index; i > 0; i--)
			{
				var cacheItem = _cacheItems[i - 1];
				_cacheItems[i] = cacheItem;
				_keyIndexDictionary[cacheItem.Key] = i;
			}

			_cacheItems[0] = new LruCacheItem {Key = key, Value = value};

			if (_cacheCount + 1 <= _maxCacheCount)
					_cacheCount++;

			_keyIndexDictionary[key] = 0;
		}

		public object Get(string key)
		{
			object value = null;
			if (_keyIndexDictionary.TryGetValue(key, out var index))
			{
				value = _cacheItems[index].Value;
				for (int i = index; i < _cacheCount - 1; i++)
				{
					var cacheItem = _cacheItems[i + 1];
					_cacheItems[i] = cacheItem;
					_keyIndexDictionary[cacheItem.Key] = i;
				}
				Add(key, value);
			}
			return value;
		}

		public object GetByIndex(int index)
		{
			if (index > _cacheCount - 1)
				return null;
			return _cacheItems[index].Value;
		}
	}
}
