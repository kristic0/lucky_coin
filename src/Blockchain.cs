using System;
using System.Collections.Generic;

namespace LuckyCoin.src
{
    class BlockChain
    {
        private List<Block> _chain;
        public BlockChain()
        {
            Console.WriteLine("BlockChain created!\n");

            _chain = new List<Block>();

            CreateGenesisBlock();
            AddBlock();
            AddBlock();
            AddBlock();

            foreach (var block in _chain)
            {
                Console.WriteLine(Helper.HashToString(block.BlockHeader.HashPrevBlock));
            }
        }

        private void CreateGenesisBlock()
        {
            _chain.Add(new Block(null));
        }

        private void AddBlock()
        {
            _chain.Add(new Block(_chain[^1].BlockHeader.HashMerkleRoot));
        }
    }
}
