using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyCoin.src
{
    class BlockChain
    {
        public BlockChain()
        {
            Console.WriteLine("BlockChain created!\n");

            List<Block> chain = new List<Block>();

            chain.Add(CreateGenesisBlock());

            //foreach(var block in chain)
            //{
            //    Console.WriteLine(block.ReadFromBlock());
            //}

        }

        private Block CreateGenesisBlock()
        {
            Console.WriteLine("Created Genesis!");
            return new Block("genesis");
        }


    }
}
