using DataStructureViaCSharp.SingleLinkedList;

namespace DataStructureViaCSharp.Common
{
	public interface ILinkedList<TData>
	{
		void InsertToHead(TData value);

		int Length { get; }

		TData FindValueByIndex(int index);

		bool DeleteByValue(TData value);

		void Insert(int index, TData value);

		void Append(TData value);

		void Clear();

		void DeleteByIndex(int index);

		TData[] ToArray();
	}
}
