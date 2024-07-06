using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Convertor.Actions
{
    public class ConverterServices
    {
        public static string TextToText(string input) =>input ;

       public static string StringToHex(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            byte[] bytes = Encoding.UTF8.GetBytes(input);
            StringBuilder hex = new StringBuilder(bytes.Length * 2);

            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }

            return hex.ToString();
        }

        public static string HexToString(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                return string.Empty;

            hex = hex.Replace(" ", "");

            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return Encoding.UTF8.GetString(bytes);
        }

       public static string TextToBinary(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            StringBuilder binary = new StringBuilder();
            foreach (char c in text)
            {
                binary.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return binary.ToString();
        }

        public static string BinaryToText(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return string.Empty;

            if (binary.Length % 8 != 0)
                throw new ArgumentException("Binary string length must be divisible by 8");

            StringBuilder text = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 8)
            {
                string chunk = binary.Substring(i, 8);
                int value = Convert.ToInt32(chunk, 2);
                text.Append((char)value);
            }
            return text.ToString();
        }

        public static string HexToBinary(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                return string.Empty;

            StringBuilder binary = new StringBuilder();
            foreach (char c in hex)
            {
                int value = Convert.ToInt32(c.ToString(), 16);
                binary.Append(Convert.ToString(value, 2).PadLeft(4, '0'));
            }
            return binary.ToString();
        }

        public static string BinaryToHex(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return string.Empty;

            if (binary.Length % 4 != 0)
                binary = binary.PadLeft(((binary.Length / 4) + 1) * 4, '0');

            StringBuilder hex = new StringBuilder();
            for (int i = 0; i < binary.Length; i += 4)
            {
                string chunk = binary.Substring(i, 4);
                int value = Convert.ToInt32(chunk, 2);
                hex.Append(value.ToString("X"));
            }
            return hex.ToString();
        }

        public static string DecimalToHex(string decimelNumber)
        {
            BigInteger res = BigInteger.Parse(decimelNumber);

            string result = res.ToString("X");

            return result;
        }

        public static BigInteger HexToDecimal(string hexNumber)
        {
            return BigInteger.Parse(hexNumber, System.Globalization.NumberStyles.HexNumber);
        }
         
        public static string DecimalToBinary(int decimalNumber)
        {
            return Convert.ToString(decimalNumber, 2);
        }
       
        public static BigInteger BinaryToDecimal(string binaryNumber)
        {
            return BigInteger.Parse(binaryNumber, System.Globalization.NumberStyles.AllowBinarySpecifier);
        }




    }
}
