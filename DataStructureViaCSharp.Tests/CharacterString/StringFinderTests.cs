using System;
using DataStructureViaCSharp.CharacterString;
using Xunit;

namespace DataStructureViaCSharp.Tests.CharacterString
{
	public class StringFinderTests
	{
		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldFindSubstringMatchesAtMiddle(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("abcdedf", "cded");
			Assert.Equal(2, index);
		}

		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldFindSubstringMatchesAtStart(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("abcdedf", "abc");
			Assert.Equal(0, index);
		}

		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldFindSubstringMatchesAtEnd(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("abcdedf", "edf");
			Assert.Equal(4, index);
		}

		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldNotFindSubstringIfNoMatches(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("abcdedf", "abce");
			Assert.Equal(-1, index);
		}

		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldNotFindSubstringInEmptyString(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("", "bdsag");
			Assert.Equal(-1, index);
		}

		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldFindSubstringWithSameLength(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("bdsag", "bdsag");
			Assert.Equal(0, index);
		}

		[Theory]
		[InlineData(nameof(SubstringMethodStringFinder))]
		[InlineData(nameof(NaiveStringFinder))]
		[InlineData(nameof(KmpStringFinder))]
		public void ShouldNotFindSubstringWithSameLengthButDifferentValue(string stringFinderTypeName)
		{
			var stringFinder = GetStringFinder(stringFinderTypeName);
			var index = stringFinder.Find("bdsag", "bdsaa");
			Assert.Equal(-1, index);
		}

		private IStringFinder GetStringFinder(string stringFinderTypeName)
		{
			return
				Activator.CreateInstance(Type.GetType(
						$"DataStructureViaCSharp.CharacterString.{stringFinderTypeName}, DataStructureViaCSharp"))
					as
					IStringFinder;
		}
	}
}
