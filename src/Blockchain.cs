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

            AddBlock(); // add msg to block class for genesis
            AddBlock();
            AddBlock();
            AddBlock();

            //foreach (var block in _chain)
            //{
            //    Console.WriteLine(Helper.HashToString(block.BlockHeader.HashPrevBlock));
            //}

            Miner miner = new Miner();

            for(int i = 0; i< _chain.Count; i++ )
            {
                Console.WriteLine("Mining block no: " + i);
                if (i == 0)
                {
                    _chain[i].BlockHeader.HashPrevBlock = null;
                }
                else
                {
                    _chain[i].SetPrevHash(_chain[i - 1].BlockHeader.HashOfBlock);
                }

                _chain[i].BlockHeader.HashOfBlock = miner.MineBlock(_chain[i]);

                Console.WriteLine("Prev hash: " + Helper.HashToString(_chain[i].BlockHeader.HashPrevBlock));
                Console.WriteLine("Block no " + i + " hash is: " + Helper.HashToString(_chain[i].BlockHeader.HashOfBlock));
                Console.WriteLine('\n');
            }
        }

        private void AddBlock()
        {
            _chain.Add(new Block());
        }
    }
}
