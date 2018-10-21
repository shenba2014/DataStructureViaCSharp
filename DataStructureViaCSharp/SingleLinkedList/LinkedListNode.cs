using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class LinkedListNode<TData>
	{
		public TData Data { get; set; }

		public LinkedListNode<TData> Next { get; set; }

		public int Index { get; set; }

		public override string ToString()
		{
			return Data.ToString();
		}
	}

	public class LinkedListHeadNode<TData> : LinkedListNode<TData>
	{
		public int ListLength { get; set; }
	}
}
