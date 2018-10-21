using System;
using System.Collections.Generic;
using DataStructureViaCSharp.Common;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class SingleLinkedList<TData> : ILinkedList<TData>
	{
		private readonly Dictionary<int, LinkedListNode<TData>> _indexNodeDictionary = new Dictionary<int, LinkedListNode<TData>>();

		public LinkedListHeadNode<TData> Head { get; private set; }

		public int Length => Head.ListLength;

		public SingleLinkedList()
		{
			Head = new LinkedListHeadNode<TData>();
		}

		public SingleLinkedList(IEnumerable<TData> values)
		{
			Init(values);
		}

		public LinkedListNode<TData> InsertToHead(TData value)
		{
			return Insert(1, value);
		}

		public LinkedListNode<TData> FindNodeByIndex(int index)
		{
			return FindNode(index);
		}

		public LinkedListNode<TData> FindNodeByValue(TData value)
		{
			LinkedListNode<TData> node = Head;
			while (node != null)
			{
				if (node.Data.Equals(value))
				{
					break;
				}
				node = node.Next;
			}

			return node;
		}

		public bool DeleteNodeByValue(TData value)
		{
			var node = FindNodeByValue(value);

			if (node != null)
			{
				var startIndex = node.Index;
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

		public LinkedListNode<TData> Insert(int index, TData data)
		{
			var node = index == 1 ? Head : FindNode(index - 1);
			if (node == null)
				return null;

			for (int i = Length + 1; i > index; i--)
			{
				_indexNodeDictionary[i] = _indexNodeDictionary[i - 1];
				_indexNodeDictionary[i].Index = i;
			}

			var newNode = new LinkedListNode<TData>
			{
				Data = data,
				Next = node.Next
			};
			node.Next = newNode;
			newNode.Index = index;
			_indexNodeDictionary[index] = newNode;

			Head.ListLength++;

			return newNode;
		}

		public LinkedListNode<TData> Append(TData data)
		{
			var lastNode = FindNode(Length) ?? Head;
			return InsertAfter(lastNode, data);
		}

		public void Clear()
		{
			LinkedListNode<TData> node = Head;
			while (node != null)
			{
				var nextNode = node.Next;
				node.Data = default(TData);
				node = nextNode;
			}
			Head.Next = null;
			Head.ListLength = 0;
		}

		public void DeleteNodeByIndex(int index)
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

		public TData[] ToArray()
		{
			var values = new TData[Length];
			var node = Head.Next;
			var i = 0;
			while (node != null)
			{
				values[i++] = node.Data;
				node = node.Next;
			}
			return values;
		}

		public void Reverse()
		{
			LinkedListNode<TData> node = Head.Next;
			LinkedListNode<TData> previousNode = null;
			while (node != null)
			{
				var next = node.Next;
				node.Next = previousNode;
				previousNode = node;
				node = next;
			}

			Head = new LinkedListHeadNode<TData> {Next = previousNode, ListLength = Head.ListLength};
		}

		private void Init(IEnumerable<TData> values)
		{
			Head = new LinkedListHeadNode<TData>();
			LinkedListNode<TData> node = Head;
			foreach (var value in values)
			{
				InsertAfter(node, value);
				node = node.Next;
			}
		}

		private LinkedListNode<TData> FindNode(int index)
		{
			if (Head == null || Head.ListLength == 0)
				return null;

			if (index < 1 || index > Head.ListLength)
				return null;

			return _indexNodeDictionary[index];
		}

		private LinkedListNode<TData> InsertAfter(LinkedListNode<TData> previousNode, TData data)
		{
			previousNode.Next = new LinkedListNode<TData> { Data = data };
			var newNode = previousNode.Next;
			newNode.Index = ++Head.ListLength;
			_indexNodeDictionary[newNode.Index] = newNode;
			return newNode;
		}
	}
}
