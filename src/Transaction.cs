using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LuckyCoin.src
{
    public class Transaction
    {
        private int _data;
        private byte[] _hash;

        public byte[] Hash { get { return _hash; } }

        public Transaction(int data)
        {
            _data = data;
            _hash = CalculateHash();

            // Console.WriteLine("tx_h: " + Helper.HashToString(_hash));
        }

        private byte[] CalculateHash()
        {
            return SHA256.Create().ComputeHash(BitConverter.GetBytes(_data));
        }
    }
}
