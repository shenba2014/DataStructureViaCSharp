using DataStructureViaCSharp.SingleLinkedList;

namespace DataStructureViaCSharp.Common
{
	public interface ILinkedList<TData>
	{
		void InsertToHead(TData value);

		int Length { get; }

		LinkedListNode<TData> FindNodeByIndex(int index);

		bool DeleteByValue(TData value);

		void Insert(int index, TData value);

		void Append(TData value);

		void Clear();

		void DeleteByIndex(int index);

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
