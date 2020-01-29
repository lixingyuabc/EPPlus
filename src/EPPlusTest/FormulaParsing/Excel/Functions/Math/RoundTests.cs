/*******************************************************************************
 * You may amend and distribute as you like, but don't remove this header!
 *
 * Required Notice: Copyright (C) EPPlus Software AB. 
 * https://epplussoftware.com
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.

 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  
 * See the GNU Lesser General Public License for more details.
 *
 * The GNU Lesser General Public License can be viewed at http://www.opensource.org/licenses/lgpl-license.php
 * If you unfamiliar with this license or have questions about it, here is an http://www.gnu.org/licenses/gpl-faq.html
 *
 * All code and executables are provided "" as is "" with no warranty either express or implied. 
 * The author accepts no liability for any damage or loss of business that this product may cause.
 *
 * Code change notes:
 * 
  Date               Author                       Change
 *******************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *******************************************************************************/
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Exceptions;

namespace EPPlusTest.FormulaParsing.Excel.Functions.Math
{
	[TestClass]
	public class RoundTests
	{
		[TestMethod]
		public void RoundPositiveToOnesDownLiteral()
		{
			Round round = new Round();
			double value1 = 123.45;
		    int digits = 0;
			var result = round.Execute(new FunctionArgument[]
			{
				new FunctionArgument(value1),
				new FunctionArgument(digits)
			}, ParsingContext.Create());
			Assert.AreEqual(123D, result.Result);
		}
        [TestMethod]
        public void RoundPositiveToOnesUpLiteral()
        {
            Round round = new Round();
            double value1 = 123.65;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(124D, result.Result);
        }

        [TestMethod]
        public void RoundPositiveToTenthsDownLiteral()
        {
            Round round = new Round();
            double value1 = 123.44;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(123.4D, result.Result);
        }
        [TestMethod]
        public void RoundPositiveToTenthsUpLiteral()
        {
            Round round = new Round();
            double value1 = 123.456;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(123.5D, result.Result);
        }
        [TestMethod]
        public void RoundPositiveToTensDownLiteral()
        {
            Round round = new Round();
            double value1 = 124;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(120D, result.Result);
        }
        [TestMethod]
        public void RoundPositiveToTensUpLiteral()
        {
            Round round = new Round();
            double value1 = 125;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(130D, result.Result);
        }

        [TestMethod]
        public void RoundNegativeToTensDownLiteral()
        {
            Round round = new Round();
            double value1 = -124;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(-120D, result.Result);
        }
        [TestMethod]
        public void RoundNegativeToTensUpLiteral()
        {
            Round round = new Round();
            double value1 = -125;
            int digits = -1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(-130D, result.Result);
        }
        [TestMethod]
        public void RoundNegativeToTenthsDownLiteral()
        {
            Round round = new Round();
            double value1 = -123.44;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(-123.4D, result.Result);
        }
        [TestMethod]
        public void RoundNegativeToTenthsUpLiteral()
        {
            Round round = new Round();
            double value1 = -123.456;
            int digits = 1;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(-123.5D, result.Result);
        }
        [TestMethod]
        public void RoundNegativeMidwayLiteral()
        {
            Round round = new Round();
            double value1 = -123.5;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(-124D, result.Result);
        }
        [TestMethod]
        public void RoundPositiveMidwayLiteral()
        {
            Round round = new Round();
            double value1 = 123.5;
            int digits = 0;
            var result = round.Execute(new FunctionArgument[]
            {
                new FunctionArgument(value1),
                new FunctionArgument(digits)
            }, ParsingContext.Create());
            Assert.AreEqual(124D, result.Result);
        }
    }
}
