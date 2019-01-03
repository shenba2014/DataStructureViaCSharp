using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructureViaCSharp.Stack;
using Xunit;
using Xunit.Sdk;

namespace DataStructureViaCSharp.Tests.Stack
{
	public class ExpressionCalculatorTest
	{
		[Theory]
		[InlineData("34+13*9+44-12/3", 191)]
		[InlineData("3+5*8-6", 37)]
		public void ShouldCalculateExpression(string expression, int expectedResult)
		{
			var expressionCalculator = new ExpressionCalculator();

			var result = expressionCalculator.Eval(expression);

			Assert.Equal(expectedResult, result);
		}
	}
}
