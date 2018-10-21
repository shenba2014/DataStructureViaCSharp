using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.SingleLinkedList;
using Xunit;

namespace DataStructureViaCSharp.Tests.SingleLinkedList
{
	public class PalindromeValidatorTest
	{
		readonly PalindromeValidator _palindromeValidator = new PalindromeValidator();

		[Theory]
		[InlineData("aba")]
		[InlineData("noon")]
		[InlineData("level")]
		[InlineData("abcdedcba")]
		[InlineData("aaaa")]
		[InlineData("a")]
		public void ShouldReturnTrueForPalindrome(string value)
		{
			Assert.True(_palindromeValidator.IsPalindrome(value), value);
		}

		[Theory]
		[InlineData("abc")]
		[InlineData("abcdefg")]
		[InlineData("eeeec")]
		public void ShouldReturnFalseForNonPalindrome(string value)
		{
			Assert.False(_palindromeValidator.IsPalindrome(value), value);
		}
	}
}
