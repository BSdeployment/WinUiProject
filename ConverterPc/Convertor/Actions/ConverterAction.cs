using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertor.Actions
{
    public class ConverterAction
    {

        public static string ConvertValues(int from,int to,string input)
        {

            string res;
            res = (from, to) switch
            {
                (0, 2) => ConverterServices.StringToHex(input),
                (2, 0) => ConverterServices.HexToString(input),

                (0, 0) => ConverterServices.TextToText(input),
                (1, 1) => ConverterServices.TextToText(input),
                (2, 2) => ConverterServices.TextToText(input),
                (3, 3) => ConverterServices.TextToText(input),

                (0, 3) => ConverterServices.TextToBinary(input),
                (3, 0) => ConverterServices.BinaryToText(input),

                (2, 3) => ConverterServices.HexToBinary(input),
                (3, 2) => ConverterServices.BinaryToHex(input),

                (1, 2) => ConverterServices.DecimalToHex(input),
                (2, 1) => ConverterServices.HexToDecimal(input).ToString(),

                (0, 1) => ConverterServices.HexToDecimal(ConverterServices.StringToHex(input)).ToString(),
                (1, 0) => ConverterServices.HexToString(ConverterServices.DecimalToHex(input)),


                _ => ""



            };



            return res;
        }
    }
}
