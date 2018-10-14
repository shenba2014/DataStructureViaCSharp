using System.Collections.Generic;
using DataStructureViaCSharp.Common;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class SingleLinkedList : ILinkedList
	{
		private readonly Dictionary<int, LinkedListNode> _indexNodeDictionary = new Dictionary<int, LinkedListNode>();

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
				var startIndex = node.Next.Index;
				if (startIndex == Length)
				{
					_indexNodeDictionary.Remove(startIndex);
				}
				else
				{
					for (var i = startIndex; i <= Length - 1; i++)
					{
						_indexNodeDictionary[i] = _indexNodeDictionary[i + 1];
					}
				}

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

			for (int i = Length + 1; i > index; i--)
			{
				_indexNodeDictionary[i] = _indexNodeDictionary[i - 1];
				_indexNodeDictionary[i].Index = i;
			}

			var newNode = new LinkedListNode
			{
				Data = data,
				Next = node.Next
			};
			node.Next = newNode;
			newNode.Index = index;
			_indexNodeDictionary[index] = newNode;

			Head.ListLength++;
		}

		public void Append(int data)
		{
			var node = FindNode(Length);
			AddNode(data, node);
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
			if (node == null || node.Next == null)
				return;

			var startIndex = node.Next.Index ;
			if (startIndex == Length)
			{
				_indexNodeDictionary.Remove(startIndex);
			}
			else
			{
				for (var i = startIndex; i <= Length - 1; i++)
				{
					_indexNodeDictionary[i] = _indexNodeDictionary[i + 1];
				}
			}
			
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
				AddNode(value, node);
				node = node.Next;
			}
		}

		private LinkedListNode FindNode(int index)
		{
			if (Head == null || Head.ListLength == 0)
				return null;

			if (index < 1 || index > Head.ListLength)
				return null;

			return _indexNodeDictionary[index];
		}

		private void AddNode(int data, LinkedListNode previousNode)
		{
			previousNode.Next = new LinkedListNode { Data = data };
			var newNode = previousNode.Next;
			newNode.Index = ++Head.ListLength;
			_indexNodeDictionary[newNode.Index] = newNode;
		}
	}
}
