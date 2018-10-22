using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class LinkedListMerger
	{
		public static LinkedListNode<TComparable> MergeImplement1<TComparable>(LinkedListNode<TComparable> source, LinkedListNode<TComparable> target)
			where TComparable : IComparable<TComparable>
		{
			LinkedListNode<TComparable> mergedNode = new LinkedListNode<TComparable>();
			LinkedListNode<TComparable> head = mergedNode;

			LinkedListNode<TComparable> sourceNode = source;
			LinkedListNode<TComparable> targetNode = target;

			while (sourceNode != null || targetNode != null)
			{
				if (targetNode == null)
				{
					mergedNode.Next = sourceNode;
					mergedNode = sourceNode;
					sourceNode = sourceNode.Next;
				}
				else if (sourceNode == null)
				{
					mergedNode.Next = targetNode;
					mergedNode = targetNode;
					targetNode = targetNode.Next;
				}
				else if (sourceNode.Data.CompareTo(targetNode.Data) <= 0)
				{
					mergedNode.Next = sourceNode;
					mergedNode = sourceNode;
					sourceNode = sourceNode.Next;
				}
				else
				{
					mergedNode.Next = targetNode;
					mergedNode = targetNode;
					targetNode = targetNode.Next;
				}
			}

			return head;
		}

		public static LinkedListNode<TComparable> MergeImplement2<TComparable>(LinkedListNode<TComparable> source,
			LinkedListNode<TComparable> target) where TComparable : IComparable<TComparable>
		{
			LinkedListNode<TComparable> mergedNode = new LinkedListNode<TComparable>();
			LinkedListNode<TComparable> head = mergedNode;

			while (source != null && target != null)
			{
				if (source.Data.CompareTo(target.Data) <= 0)
				{
					mergedNode.Next = source;
					source = source.Next;
				}
				else
				{
					mergedNode.Next = target;
					target = target.Next;
				}

				mergedNode = mergedNode.Next;
			}

			mergedNode.Next = source ?? target;

			return head;
		}
	}
}
