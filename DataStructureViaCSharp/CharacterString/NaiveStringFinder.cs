using System;

namespace DataStructureViaCSharp.CharacterString
{
	public class NaiveStringFinder : IStringFinder
	{
		public int Find(string target, string substring)
		{
			if (string.IsNullOrWhiteSpace(substring))
				throw new ArgumentNullException(nameof(substring));

			if (string.IsNullOrWhiteSpace(target))
				return -1;

			var targetLength = target.Length;
			var substringLength = substring.Length;

			if (substringLength > targetLength)
				return -1;
			if (substringLength == targetLength
			    && !target.Equals(substring))
				return -1;

			var i = 0;
			var j = 0;
			while (i < targetLength && j < substringLength)
				if (target[i] == substring[j])
				{
					i++;
					j++;
				}
				else
				{
					i = i - j + 1;
					j = 0;
				}

			if (j == substringLength)
				return i - j;

			return -1;
		}
	}
}
