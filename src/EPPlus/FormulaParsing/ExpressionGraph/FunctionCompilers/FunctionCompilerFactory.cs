/*************************************************************************************************
  Required Notice: Copyright (C) EPPlus Software AB. 
  This software is licensed under PolyForm Noncommercial License 1.0.0 
  and may only be used for noncommercial purposes 
  https://polyformproject.org/licenses/noncommercial/1.0.0/

  A commercial license to use this software can be purchased at https://epplussoftware.com
 *************************************************************************************************
  Date               Author                       Change
 *************************************************************************************************
  01/27/2020         EPPlus Software AB       Initial release EPPlus 5
 *************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Utilities;

namespace OfficeOpenXml.FormulaParsing.ExpressionGraph.FunctionCompilers
{
    public class FunctionCompilerFactory
    {
        private readonly Dictionary<Type, FunctionCompiler> _specialCompilers = new Dictionary<Type, FunctionCompiler>();
        private readonly ParsingContext _context;
        public FunctionCompilerFactory(FunctionRepository repository, ParsingContext context)
        {
            Require.That(context).Named("context").IsNotNull();
            _context = context;
            _specialCompilers.Add(typeof(If), new IfFunctionCompiler(repository.GetFunction("if"), context));
            _specialCompilers.Add(typeof(IfError), new IfErrorFunctionCompiler(repository.GetFunction("iferror"), context));
            _specialCompilers.Add(typeof(IfNa), new IfNaFunctionCompiler(repository.GetFunction("ifna"), context));
            foreach (var key in repository.CustomCompilers.Keys)
            {
              _specialCompilers.Add(key, repository.CustomCompilers[key]);
            }
        }

        private FunctionCompiler GetCompilerByType(ExcelFunction function)
        {
            var funcType = function.GetType();
            if (_specialCompilers.ContainsKey(funcType))
            {
                return _specialCompilers[funcType];
            }
            return new DefaultCompiler(function, _context);
        }
        public virtual FunctionCompiler Create(ExcelFunction function)
        {
            if (function.IsLookupFuction) return new LookupFunctionCompiler(function, _context);
            if (function.IsErrorHandlingFunction) return new ErrorHandlingFunctionCompiler(function, _context);
            return GetCompilerByType(function);
        }
    }
}
