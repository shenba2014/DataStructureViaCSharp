using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class LinkedListNode
	{
		public int Data { get; set; }

		public LinkedListNode Next { get; set; }

		public int Index { get; set; }
	}

	public class LinkedListHeadNode : LinkedListNode
	{
		public int ListLength { get; set; }
	}
}
