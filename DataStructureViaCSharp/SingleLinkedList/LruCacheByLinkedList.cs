﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class LruCacheByLinkedList
	{
		private readonly SingleLinkedList<int> _linkedList = new SingleLinkedList<int>();

		private readonly int _maxCacheCount;

		public LruCacheByLinkedList(int maxCacheCount)
		{
			_maxCacheCount = maxCacheCount;
		}

		public void Add(int value)
		{
			if (_linkedList.Length + 1 > _maxCacheCount)
			{
				RemoveLastElement();
			}
			_linkedList.InsertToHead(value);
		}

		public int? GetByIndex(int index)
		{
			var node = _linkedList.FindNodeByIndex(index);
			return node?.Data;
		}

		public int? GetByValue(int value)
		{
			if (_linkedList.DeleteNodeByValue(value))
			{
				_linkedList.InsertToHead(value);
				return value;
			}
			return null;
		}

		private void RemoveLastElement()
		{
			_linkedList.DeleteNodeByIndex(_linkedList.Length);
		}
	}
}
