using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.CharacterString
{
	public class KmpStringFinder : IStringFinder
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

			var next = getNextArrayOptimized(substring);

			var i = 0;
			var j = 0;
			while (i < targetLength && j < substringLength)
				if (j == 0 || target[i] == substring[j])
				{
					i++;
					j++;
				}
				else
				{
					j = next[j - 1];
				}

			if (j == substringLength)
				return i - j;

			return -1;
		}

		private int[] getNextArray(string substring)
		{
			var substringLength = substring.Length;
			var next = new int[substringLength];
			next[0] = 0;
			var i = 1;
			var j = 0;
			while (i < substringLength)
			{
				if (j == 0 || substring[i] == substring[j])
				{
					i++;
					j++;
					next[i - 1] = j;
				}
				else
				{
					j = next[j - 1];
				}
			}
			return next;
		}

		private int[] getNextArrayOptimized(string substring)
		{
			var substringLength = substring.Length;
			var next = new int[substringLength];
			next[0] = 0;
			var i = 1;
			var j = 0;
			while (i < substringLength)
			{
				if (j == 0 || substring[i] == substring[j])
				{
					i++;
					j++;
					if (i < substringLength && substring[i] != substring[j])
					{
						next[i - 1] = j;
					}
					else
					{
						next[i - 1] = next[j - 1];
					}
				}
				else
				{
					j = next[j - 1];
				}
			}
			return next;
		}
	}
}
