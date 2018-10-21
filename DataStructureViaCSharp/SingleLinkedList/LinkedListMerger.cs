using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.SingleLinkedList
{
	public class LinkedListMerger
	{
		public static SingleLinkedList<TComparable> Merge<TComparable>(SingleLinkedList<TComparable> source, SingleLinkedList<TComparable> target)
			where TComparable : IComparable<TComparable>
		{
			var mergedLinkedList = new SingleLinkedList<TComparable>();

			LinkedListNode<TComparable> sourceNode = source.Head.Next;
			LinkedListNode<TComparable> targetNode = target.Head.Next;

			while (sourceNode != null || targetNode != null)
			{
				if (targetNode == null)
				{
					mergedLinkedList.Append(sourceNode.Data);
					sourceNode = sourceNode.Next;
				}
				else if (sourceNode == null)
				{
					mergedLinkedList.Append(targetNode.Data);
					targetNode = targetNode.Next;
				}
				else if (sourceNode.Data.CompareTo(targetNode.Data) <= 0)
				{
					mergedLinkedList.Append(sourceNode.Data);
					sourceNode = sourceNode.Next;
				}
				else
				{
					mergedLinkedList.Append(targetNode.Data);
					targetNode = targetNode.Next;
				}
			}

			return mergedLinkedList;
		}
	}
}
