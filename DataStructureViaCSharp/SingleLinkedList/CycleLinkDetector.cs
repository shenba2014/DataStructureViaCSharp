using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class CycleLinkDetector
	{
		public bool ExistsCycleLink<TData>(SingleLinkedList<TData> singleLinkedList)
		{
			LinkedListNode<TData> fast = singleLinkedList.Head;
			LinkedListNode<TData> slow = singleLinkedList.Head;
			while (fast?.Next != null)
			{
				fast = fast.Next.Next;
				slow = slow.Next;

				if (fast == slow)
				{
					return true;
				}
			}

			return false;
		}

		public LinkedListNode<TData> FindCycleEntryNode<TData>(SingleLinkedList<TData> singleLinkedList)
		{		
			return null;
		}
	}
}
