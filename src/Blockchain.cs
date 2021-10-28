using System;
using System.Collections.Generic;

namespace LuckyCoin.src
{
    class BlockChain
    {
        public List<Block> Chain { get; private set; }

        public BlockChain()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Blockchain created!\n");
            Console.ResetColor();

            Chain = new List<Block>();
        }
    }
    
}
