using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyCoin.src
{
    public class TransactionPool
    {
        private static TransactionPool _instance = null;
        private static readonly object _lock = new object();

        private const int MaxTxs = 400;
        Queue<Transaction> _txs = new Queue<Transaction>();

        public Queue<Transaction> Transactions { get { return _txs ;} }

        private TransactionPool()
        {
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Tx pool started!\n"); 
            Console.ResetColor();

            for (int i = 0; i < MaxTxs; i++)
            {
                AddTxToPool(Helper.GenerateFakeTx());
            }
        }

        public static TransactionPool Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new TransactionPool();
                    }
                }

                return _instance;
            }
        }
        
        public void AddTxToPool(Transaction tx)
        {
            if(_txs.Count < 400)
            {
                _txs.Enqueue(tx);
            } 
        }
    }
}
