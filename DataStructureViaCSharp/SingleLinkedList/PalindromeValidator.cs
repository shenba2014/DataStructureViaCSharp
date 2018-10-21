using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class PalindromeValidator
	{
		public bool IsPalindrome(string value)
		{
			var linkedList = new SingleLinkedList<char>(value);

			LinkedListNode<char> prev = null;
			LinkedListNode<char> slow = linkedList.Head;
			LinkedListNode<char> fast = linkedList.Head;

			while (fast?.Next != null)
			{
				fast = fast.Next.Next;
				var next = slow.Next;
				slow.Next = prev;
				prev = slow;
				slow = next;
			}

			if (linkedList.Length % 2 != 0)
			{
				slow = slow.Next;
			}
			else
			{
				var next = slow.Next;
				slow.Next = prev;
				prev = slow;
				slow = next;
			}

			while (slow != null)
			{
				if (!slow.Data.Equals(prev.Data))
				{
					return false;
				}
				slow = slow.Next;
				prev = prev.Next;
			}

			return true;
		}
	}
}
