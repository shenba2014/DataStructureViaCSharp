using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.SingleLinkedList;
using Xunit;

namespace DataStructureViaCSharp.Tests.SingleLinkedList
{
	public class CycleLinkDetectorTest
	{
		CycleLinkDetector _cycleLinkDetector = new CycleLinkDetector();

		[Fact]
		public void CouldDetectCycleLinkStartFromMiddle()
		{
			var cycleLinkedList = new SingleLinkedList<int>();
			var node1 = cycleLinkedList.Append(1);
			var node2 = cycleLinkedList.Append(2);
			var node3 = cycleLinkedList.Append(3);
			var node4 = cycleLinkedList.Append(4);
			var node5 = cycleLinkedList.Append(5);
			// make a cycle
			node5.Next = node3;

			Assert.True(_cycleLinkDetector.ExistsCycleLink(cycleLinkedList));
		}

		[Fact]
		public void CouldDetectCycleLinkStartFromHead()
		{
			var cycleLinkedList = new SingleLinkedList<int>();
			var node1 = cycleLinkedList.Append(1);
			var node2 = cycleLinkedList.Append(2);
			var node3 = cycleLinkedList.Append(3);
			var node4 = cycleLinkedList.Append(4);
			var node5 = cycleLinkedList.Append(5);
			// make a cycle
			node5.Next = node1;

			Assert.True(_cycleLinkDetector.ExistsCycleLink(cycleLinkedList));
		}

		[Fact]
		public void ShouldReturnFalseForNoLinkExists()
		{
			var noCycleLinkedList = new SingleLinkedList<int>();
			var node1 = noCycleLinkedList.Append(1);
			var node2 = noCycleLinkedList.Append(2);
			var node3 = noCycleLinkedList.Append(3);
			var node4 = noCycleLinkedList.Append(4);
			var node5 = noCycleLinkedList.Append(5);

			Assert.False(_cycleLinkDetector.ExistsCycleLink(noCycleLinkedList));
		}
	}
}
