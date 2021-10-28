using System;

namespace LuckyCoin
{
    public class TxOut
    {
        public ulong Amount { get; set; }
        public string RecipientAddr { get; set; }

        public TxOut()
        {
            Amount = 0;
            RecipientAddr = null;
        }
    }
}