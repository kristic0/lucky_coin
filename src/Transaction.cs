using System;
using System.Security.Cryptography;

namespace LuckyCoin.src
{
    public class Transaction
    {
        private byte[] _sendersAddress;
        private byte[] _receiversAddress;
        private decimal _amount;

        public byte[] Hash { get; }
        private int Data { get; set; }

        public Transaction(int data, byte[] sendersAddress, byte[] receiversAddress, decimal amount)
        {
            Data = data;
            _sendersAddress = sendersAddress;
            _receiversAddress = receiversAddress;
            _amount = amount;
            Hash = CalculateHash();
        }

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
