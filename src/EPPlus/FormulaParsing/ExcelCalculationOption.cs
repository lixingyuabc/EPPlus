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

namespace OfficeOpenXml.FormulaParsing
{
    /// <summary>
    /// Options used by the formula parser
    /// </summary>
    public class ExcelCalculationOption
    {
        public ExcelCalculationOption()
        {
            AllowCircularReferences = false;
        }
        /// <summary>
        /// Do not throw an exception if the formula parser encounters a circular reference
        /// </summary>
        public bool AllowCircularReferences { get; set; }
    }
}
