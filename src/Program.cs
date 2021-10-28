using System;
using LuckyCoin.src;
using LuckyCoin.src.Merkle;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LuckyCoin
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Options: \n1)Start miner\n2)Create wallet");
            var input = Console.ReadLine();
            switch (Int32.Parse(input))
            {
                case 1:
                    StartMiner();
                    break;
                case 2:
                    CreateWallet();
                    break;
            }
        }

        private static void StartMiner()
        {
            // todo: check network for existing blockchain
            var blockChain = new BlockChain();
            var miner = new Miner(blockChain.Chain, TransactionPool.Instance);
        }

        private static void CreateWallet()
        {
            var wlt = new Wallet("idk rand phrase");
        }
        
    }
}
