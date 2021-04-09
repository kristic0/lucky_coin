using System;
using System.Collections.Generic;

namespace LuckyCoin.src
{
    class BlockChain
    {
        private List<Block> _chain;
        public List<Block> Chain { get => _chain; set => _chain = value; }
        public BlockChain(TransactionPool txPool)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Blockchain created!\n");
            Console.ResetColor();

            Chain = new List<Block>();
        }
    }
}
