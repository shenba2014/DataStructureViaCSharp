using DataStructureViaCSharp.SingleLinkedList;

namespace DataStructureViaCSharp.Common
{
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
