using LuckyCoin.src;
using LuckyCoin.src.Merkle;
using System.Collections.Generic;

namespace LuckyCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionPool txPool = TransactionPool.Instance;
            BlockChain blockChain = new BlockChain(txPool);
            Miner miner = new Miner(blockChain.Chain, txPool);
        }
    }
}
