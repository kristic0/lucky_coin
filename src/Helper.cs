using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyCoin.src
{
    public static class Helper
    {
        // Loop through each byte of the hashed data
        // and format each one as a *hexadecimal* string.
        public static string HashToString(byte[] byteArray)
        {
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

            for (int i = 0; i < 9; i++)
            {
                transactions.Add(new Transaction(i));
                // transactions.Add(new Transaction(rand.Next()));

                // Console.WriteLine(transactions[i]);
            }

            return transactions;
        }
    }
}
