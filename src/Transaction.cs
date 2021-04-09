using System;
using System.Security.Cryptography;

namespace LuckyCoin.src
{
    public class Transaction
    {
        private readonly int _data;
        private readonly byte[] _hash;
        private byte[] _sendersAddress;
        private byte[] _receiversAddress;
        private decimal _amount;

        public byte[] Hash { get { return _hash; } }

        public Transaction(int data, byte[] sendersAddress, byte[] receiversAddress, decimal amount)
        {
            _data = data;
            _sendersAddress = sendersAddress;
            _receiversAddress = receiversAddress;
            _amount = amount;
            _hash = CalculateHash();
        }

        public Transaction(int data)
        {
            _data = data;
            _hash = CalculateHash();
        }

        private byte[] CalculateHash()
        {
            return SHA256.Create().ComputeHash(BitConverter.GetBytes(_data));
        }
    }
}
