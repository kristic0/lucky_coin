using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LuckyCoin.src
{
    public static class Helper
    {
        // Loop through each byte of the hashed data
        // and format each one as a *hexadecimal* string.
        public static string ByteArrToString(byte[] byteArray)
        {
            if(byteArray == null) { return "null"; }

            StringBuilder Sb = new StringBuilder();
            Sb.Append("0x");
            foreach (Byte b in byteArray)
                Sb.Append(b.ToString("x2"));

            return Sb.ToString();
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
            Transaction tx;
            Random rand = new Random();

            tx = new Transaction(rand.Next());

            return tx;
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
