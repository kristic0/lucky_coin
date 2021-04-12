using System;
using LuckyCoin.src;
using LuckyCoin.src.Merkle;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LuckyCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var txPool = TransactionPool.Instance;
            var blockChain = new BlockChain(txPool);
            var miner = new Miner(blockChain.Chain, txPool);
        }
    }
}
