using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{
    public class StringUtils
    {
        public static string BytesArrayToHexString(sbyte[] Bytes)
        {
            StringBuilder Result = new StringBuilder(Bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (sbyte B in Bytes)
            {
                var b = B + 128;
                Result.Append(HexAlphabet[(int)(b >> 4)]);
                Result.Append(HexAlphabet[(int)(b & 0xF)]);
            }
            
            return Result.ToString().ToLower();
        }
        public static byte[] hexToBytes(string hexstring)
        {
            if (hexstring == null || hexstring.Length == 0)
            {
                return null;
            }
            sbyte[] results = new sbyte[hexstring.Length / 2];
            int resIdx = 0;
            try
            {
                for (int i = 0; i < hexstring.Length; i += 2)
                {
                    results[resIdx] = (sbyte)(Convert.ToInt32("" + hexstring[i] + hexstring[i + 1], 16) - 128);
                    resIdx++;
                }
            }
            catch
            {
                throw new Exception($"Can not decode hex string: {hexstring} ");
            }
            return Array.ConvertAll(results, b => unchecked((byte)b));
        }
        public static sbyte[] ConvertArrayBytesToSbyte(byte[] bytes)
        {
            return Array.ConvertAll(bytes, b => unchecked((sbyte)b));
        }
        public static sbyte[] GetSbytes(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return Array.ConvertAll(bytes, b => unchecked((sbyte)b));
        }
        public static byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
