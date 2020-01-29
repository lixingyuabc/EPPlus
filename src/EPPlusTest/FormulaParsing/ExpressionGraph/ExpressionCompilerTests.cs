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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using ExpGraph = OfficeOpenXml.FormulaParsing.ExpressionGraph.ExpressionGraph;
using OfficeOpenXml.FormulaParsing.Excel.Operators;

namespace EPPlusTest.FormulaParsing.ExpressionGraph
{
    [TestClass]
    public class ExpressionCompilerTests
    {
        private IExpressionCompiler _expressionCompiler;
        private ExpGraph _graph;
        
        [TestInitialize]
        public void Setup()
        {
            _expressionCompiler = new ExpressionCompiler();
            _graph = new ExpGraph();
        }

        [TestMethod]
        public void ShouldCompileTwoInterExpressionsToCorrectResult()
        {
            var exp1 = new IntegerExpression("2");
            exp1.Operator = Operator.Plus;
            _graph.Add(exp1);
            var exp2 = new IntegerExpression("2");
            _graph.Add(exp2);

            var result = _expressionCompiler.Compile(_graph.Expressions);

            Assert.AreEqual(4d, result.Result);
        }


        [TestMethod]
        public void CompileShouldMultiplyGroupExpressionWithFollowingIntegerExpression()
        {
            var groupExpression = new GroupExpression(false);
            groupExpression.AddChild(new IntegerExpression("2"));
            groupExpression.Children.First().Operator = Operator.Plus;
            groupExpression.AddChild(new IntegerExpression("3"));
            groupExpression.Operator = Operator.Multiply;

            _graph.Add(groupExpression);
            _graph.Add(new IntegerExpression("2"));

            var result = _expressionCompiler.Compile(_graph.Expressions);

            Assert.AreEqual(10d, result.Result);
        }

        [TestMethod]
        public void CompileShouldCalculateMultipleExpressionsAccordingToPrecedence()
        {
            var exp1 = new IntegerExpression("2");
            exp1.Operator = Operator.Multiply;
            _graph.Add(exp1);
            var exp2 = new IntegerExpression("2");
            exp2.Operator = Operator.Plus;
            _graph.Add(exp2);
            var exp3 = new IntegerExpression("2");
            exp3.Operator = Operator.Multiply;
            _graph.Add(exp3);
            var exp4 = new IntegerExpression("2");
            _graph.Add(exp4);

            var result = _expressionCompiler.Compile(_graph.Expressions);

            Assert.AreEqual(8d, result.Result);
        }
    }
}
