using System;
using System.Collections.Generic;

namespace DataStructureViaCSharp.StaticLinkedList
{
	public class StaticLinkedList
	{
		private Item[] _items;

		public Item Head { get; private set; }

		public int Length => Head.Cur - 1;

		public StaticLinkedList(IReadOnlyList<int> values)
		{
			Init(values);
		}

		public void Insert(int index, int data)
		{
			var item = index == 1 ? _items[1] : Find(index - 1);
			if (item == null)
				return;

			var newItem = new Item {Data = data};

			// point to the Cur of newItem
			item.Cur = Head.Cur;
			
			// Cur of newItem should be index
			newItem.Cur = index;

			_items[Head.Cur] = newItem;
			// point to next empty position
			Head.Cur++;
		}

		public Item Find(int index)
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
			var values = new int[Head.Cur - 1];
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
			_items = new Item[values.Count * 2];
			Head = new Item {Cur = values.Count + 1};
			_items[0] = Head;
			for (var i = 1; i <= values.Count; i++)
				_items[i] = new Item
				{
					Data = values[i - 1],
					Cur = i + 1
				};
			_items[_items.Length - 1] = new Item {Cur = 1};
		}
	}
}
