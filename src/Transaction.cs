using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace LuckyCoin.src
{
    public class Transaction
    {
        public List<TxIn> Inputs { get; set; }
        public List<TxOut> Outputs { get; set; }

        public byte[] Hash { get; }
        private int Data { get; set; }

        private DateTime lockTime; // can't happen until this date -- impl much later

        public Transaction(int data)
        {
            Data = data;
            Inputs = new List<TxIn>();
            Outputs = new List<TxOut>();
            Hash = CalculateHash();
        }
        
        public Transaction()
        {
            Inputs = new List<TxIn>();
            Outputs = new List<TxOut>();
            Hash = CalculateHash();
        }

        private byte[] CalculateHash()
        {
            var input = BitConverter.GetBytes(Inputs.GetHashCode());
            var output = BitConverter.GetBytes(Outputs.GetHashCode());
            var data = BitConverter.GetBytes(Data);
            
            return SHA256.Create().ComputeHash(
                input
                    .Concat(output)
                    .Concat(data)
                    .ToArray()
                );
        }
    }
}
