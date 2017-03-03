using System;
using System.Collections.Generic;
using DataStructureViaCSharp.Common;

namespace DataStructureViaCSharp.StaticLinkedList
{
	public class StaticLinkedList
	{
		private StaticLinkedListNode[] _items;

		public StaticLinkedListNode Head { get; private set; }

		public int Length { get; private set; }

		public StaticLinkedList(IReadOnlyList<int> values)
		{
			Init(values);
		}

		public void Insert(int index, int data)
		{
			var item = index == 1 ? _items[1] : Find(index - 1);
			if (item == null)
				return;

			var newItem = new StaticLinkedListNode {Data = data};

			// point to the Cur of newItem
			item.Cur = Head.Cur;
			
			// Cur of newItem should be index
			newItem.Cur = index;

			_items[Head.Cur] = newItem;
			// point to next empty position
			Head.Cur++;
			Length++;
		}

		public void Delete(int index)
		{
			var preItem = index == 1 ? _items[_items.Length - 1] : Find(index - 1);
			if (preItem == null)
				return;
			var toDeleteItemIndex = preItem.Cur;
			preItem.Cur = _items[toDeleteItemIndex].Cur;
			_items[toDeleteItemIndex] = null;
			SetFirstNotNullIndex();
			Length--;
		}

		private void SetFirstNotNullIndex()
		{
			for (int i = 1; i < _items.Length; i++)
			{
				if (_items[i] != null) continue;
				Head.Cur = i;
				break;
			}
		}

		public StaticLinkedListNode Find(int index)
		{
			if (index < 0)
				return null;
			if (index > _items.Length - 1)
				return null;

			var k = _items.Length - 1;
			var i = 0;
			while (i < index)
			{
				var nextItemIndex = _items[k].Cur;
				k = nextItemIndex;
				i++;
			}

			return _items[k];
		}

		public int[] ToArray()
		{
			var values = new int[Length];
			var k = _items.Length - 1;
			var firstIndex = _items[k].Cur;
			var item = _items[firstIndex];
			var i = 0;
			while (item != null && i < values.Length)
			{
				values[i++] = item.Data;
				item = _items[item.Cur];
			}
			return values;
		}

		private void Init(IReadOnlyList<int> values)
		{
			_items = new StaticLinkedListNode[values.Count * 2];
			Head = new StaticLinkedListNode {Cur = values.Count + 1};
			_items[0] = Head;
			for (var i = 1; i <= values.Count; i++)
				_items[i] = new StaticLinkedListNode
				{
					Data = values[i - 1],
					Cur = i + 1
				};
			_items[_items.Length - 1] = new StaticLinkedListNode {Cur = 1};
			Length = values.Count;
		}
	}
}
