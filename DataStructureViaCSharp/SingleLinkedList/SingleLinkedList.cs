using System.Collections.Generic;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class SingleLinkedList
	{
		public SingleLinkedList(IEnumerable<int> values)
		{
			Init(values);
		}

		public HeadNode Head { get; private set; }

		public int Length => Head.ListLength;

		public Node Find(int index)
		{
			if (Head == null || Head.ListLength == 0)
				return null;

			if (index < 1 || index > Head.ListLength)
				return null;

			Node node = Head;
			var count = 0;
			while (node != null && count < index)
			{
				node = node.Next;
				count++;
			}

			return node;
		}

		public void Insert(int index, int data)
		{
			var node = index == 1 ? Head : Find(index - 1);
			if (node == null)
				return;

			var newNode = new Node
			{
				Data = data,
				Next = node.Next
			};
			node.Next = newNode;

			Head.ListLength++;
		}

		public void Append(int data)
		{
			var node = Find(Length);
			node.Next = new Node {Data = data};
			Head.ListLength++;
		}

		public void Clear()
		{
			Node node = Head;
			while (node != null)
			{
				var nexNode = node.Next;
				node.Data = 0;
				node = nexNode;
			}
			Head.Next = null;
			Head.ListLength = 0;
		}

		public void Delete(int index)
		{
			var node = index == 1 ? Head : Find(index - 1);
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
			Head = new HeadNode();
			Node node = Head;
			foreach (var value in values)
			{
				node.Next = new HeadNode {Data = value};
				node = node.Next;
				Head.ListLength++;
			}
		}
	}
}
