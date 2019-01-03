using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStructureViaCSharp.Stack
{
	public class ExpressionCalculator
	{
		private static readonly Dictionary<string, int> PriorityDictionary = new Dictionary<string, int>
		{
			{"+", 0 },
			{"-", 0 },
			{"*", 1 },
			{"/", 1 },
		};

		public int Eval(string expression)
		{
			var numbers = new SimpleStack<int>(10);

			var operators = new SimpleStack<string>(10);

			var matches = Regex.Matches(expression, @"(\d+|[\+\-\*/])");

			for (int i = 0; i < matches.Count; i++)
			{
				var value = matches[i].Value;
				if (int.TryParse(value, out var number))
				{
					numbers.Push(number);
				}
				else
				{
					if (operators.Count > 0)
					{
						var currentOperator = value;
						var lastOperator = operators.Pop();

						var lastOperatorPriority = PriorityDictionary[lastOperator];
						var currentOperatorPriority = PriorityDictionary[currentOperator];

						if (currentOperatorPriority > lastOperatorPriority)
						{
							operators.Push(lastOperator);
						}
						else
						{
							while (currentOperatorPriority <= lastOperatorPriority)
							{
								var number2 = numbers.Pop();
								var number1 = numbers.Pop();
								var result = Calculate(number1, number2, lastOperator);
								numbers.Push(result);

								lastOperator = operators.Pop();
								if (lastOperator == null)
								{
									break;
								}
								lastOperatorPriority = PriorityDictionary[lastOperator];
							}
						}
					}

					operators.Push(value);
				}
			}

			while (operators.Count > 0)
			{
				var n2 = numbers.Pop();
				var n1 = numbers.Pop();
				var @operator = operators.Pop();
				numbers.Push(Calculate(n1, n2, @operator));
			}

			return numbers.Pop();
		}

		private int Calculate(int number1, int number2, string @operator)
		{
			switch (@operator)
			{
				case "+":
					return number1 + number2;
				case "-":
					return number1 - number2;
				case "*":
					return number1 * number2;
				case "/":
					return number1 / number2;
				default:
					throw new ArgumentException();
			}
		}
	}
}
