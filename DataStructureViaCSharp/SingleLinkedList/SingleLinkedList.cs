using System.Collections.Generic;
using DataStructureViaCSharp.Common;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class SingleLinkedList : ILinkedList
	{
		public LinkedListHeadNode Head { get; private set; }

		public int Length => Head.ListLength;

		public SingleLinkedList()
		{
			Head = new LinkedListHeadNode();
		}

		public SingleLinkedList(IEnumerable<int> values)
		{
			Init(values);
		}

		public void InsertToHead(int value)
		{
			Insert(1, value);
		}

		public int? FindValueByIndex(int index)
		{
			return FindNode(index)?.Data;
		}

		public bool DeleteByValue(int value)
		{
			LinkedListNode node = Head;
			while (node?.Next != null && node.Next.Data != value)
			{
				node = node.Next;
			}

			if (node != null && node.Next?.Data == value)
			{
				node.Next = node.Next?.Next;
				Head.ListLength--;
				return true;
			}

			return false;
		}

		public void Insert(int index, int data)
		{
			var node = index == 1 ? Head : FindNode(index - 1);
			if (node == null)
				return;

			var newNode = new LinkedListNode
			{
				Data = data,
				Next = node.Next
			};
			node.Next = newNode;

			Head.ListLength++;
		}

		public void Append(int data)
		{
			var node = FindNode(Length);
			node.Next = new LinkedListNode { Data = data};
			Head.ListLength++;
		}

		public void Clear()
		{
			LinkedListNode node = Head;
			while (node != null)
			{
				var nexNode = node.Next;
				node.Data = 0;
				node = nexNode;
			}
			Head.Next = null;
			Head.ListLength = 0;
		}

		public void DeleteByIndex(int index)
		{
			var node = index == 1 ? Head : FindNode(index - 1);
			if (node == null)
				return;
			node.Next = node.Next?.Next;
			Head.ListLength--;
		}

		public int[] ToArray()
		{
			var values = new int[Length];
			var node = Head.Next;
			var i = 0;
			while (node != null)
			{
				values[i++] = node.Data;
				node = node.Next;
			}
			return values;
		}

		private void Init(IEnumerable<int> values)
		{
			Head = new LinkedListHeadNode();
			LinkedListNode node = Head;
			foreach (var value in values)
			{
				node.Next = new LinkedListNode { Data = value};
				node = node.Next;
				Head.ListLength++;
			}
		}

		private LinkedListNode FindNode(int index)
		{
			if (Head == null || Head.ListLength == 0)
				return null;

			if (index < 1 || index > Head.ListLength)
				return null;

			LinkedListNode node = Head;
			var count = 0;
			while (node != null && count < index)
			{
				node = node.Next;
				count++;
			}

			return node;
		}
	}
}
