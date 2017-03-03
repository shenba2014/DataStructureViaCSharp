namespace DataStructureViaCSharp.Common
{
	public interface ILinkedList
	{
		int Length { get; }

		int? Find(int index);

		void Insert(int index, int data);

		void Append(int data);

		void Clear();

		void Delete(int index);

		int[] ToArray();
	}
}
