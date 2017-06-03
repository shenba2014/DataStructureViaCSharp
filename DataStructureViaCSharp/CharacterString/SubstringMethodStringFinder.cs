using System;

namespace DataStructureViaCSharp.CharacterString
{
	public class SubstringMethodStringFinder : IStringFinder
	{
		public int Find(string target, string substring)
		{
			if (string.IsNullOrWhiteSpace((substring)))
				throw new ArgumentNullException(nameof(substring));

			if (string.IsNullOrWhiteSpace((target)))
				return -1;

			var targetLength = target.Length;
			var substringLength = substring.Length;

			if (substringLength > targetLength)
			{
				return -1;
			}
			if (substringLength == targetLength
				&& !target.Equals(substring))
			{
				return -1;
			}

			var i = 0;
			while (i <= targetLength - substringLength)
			{
				var substringInTarget = target.Substring(i, substringLength);
				if (substringInTarget.Equals((substring)))
				{
					break;
				}
				i++;
			}

			if (i > targetLength - substringLength)
				return -1;
			return i;
		}
	}
}
