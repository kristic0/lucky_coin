using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LuckyCoin.src
{
    public static class Helper
    {
        private static readonly uint[] _lookup32 = CreateLookup32();

        private static uint[] CreateLookup32()
        {
            var result = new uint[256];
            for (int i = 0; i < 256; i++)
            {
                string s=i.ToString("x2");
                result[i] = ((uint)s[0]) + ((uint)s[1] << 16);
            }
            return result;
        }
        public static string ByteArrToString(byte[] byteArray)
        {
            // if(byteArray == null) { return "null"; }
            //
            // StringBuilder Sb = new StringBuilder();
            // Sb.Append("0x");
            // foreach (Byte b in byteArray)
            //     Sb.Append(b.ToString("x2"));
            //
            // return Sb.ToString();
            var lookup32 = _lookup32;
            var result = new char[byteArray.Length * 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                var val = lookup32[byteArray[i]];
                result[2*i] = (char)val;
                result[2*i + 1] = (char) (val >> 16);
            }
            
            return new string(result);
        }

        public static List<Transaction> PopulateFakeTx()
        {
            List<Transaction> transactions = new List<Transaction>();
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                // transactions.Add(new Transaction(i));
                transactions.Add(new Transaction(rand.Next()));

                //Console.WriteLine(transactions[i]);
            }

            return transactions;
        }

        public static Transaction GenerateFakeTx()
        {
            return new Transaction(new Random().Next());
        }

        public static byte[] FromHexToByteArray(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return raw;
        }
    }
}
