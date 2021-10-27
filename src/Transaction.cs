using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace LuckyCoin.src
{
    public class Transaction
    {
        public string Id;
        public List<TxIn> Inputs = new List<TxIn>();
        public List<TxOut> Outputs = new List<TxOut>();

        public byte[] Hash { get; }
        private int Data { get; set; }

        // public Transaction()
        // {
        //     
        //     Hash = CalculateHash();
        // }

        public Transaction(int data)
        {
            Data = data;
            Hash = CalculateHash();
        }

        private byte[] CalculateHash()
        {
            return SHA256.Create().ComputeHash(BitConverter.GetBytes(Data));
        }
    }
}
