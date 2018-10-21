using System;
using System.Collections.Generic;
using DataStructureViaCSharp.SingleLinkedList;

namespace DataStructureViaCSharp.Common
{
	public interface ILinkedList<TData>
	{
		SingleLinkedList.LinkedListNode<TData> InsertToHead(TData value);

		int Length { get; }

		SingleLinkedList.LinkedListNode<TData> FindNodeByIndex(int index);

		SingleLinkedList.LinkedListNode<TData> FindNodeByValue(TData value);

		bool DeleteNodeByValue(TData value);

		void DeleteNodeByIndex(int index);

		SingleLinkedList.LinkedListNode<TData> Insert(int index, TData value);

		SingleLinkedList.LinkedListNode<TData> Append(TData value);

		void Clear();

		TData[] ToArray();

		void Reverse();
	}

	public interface ILinkedList
	{
		void InsertToHead(int value);

		int Length { get; }

		int? FindValueByIndex(int index);

		bool DeleteByValue(int value);

		void Insert(int index, int value);

		void Append(int value);

		void Clear();

		void DeleteByIndex(int index);

		int[] ToArray();
	}
}
