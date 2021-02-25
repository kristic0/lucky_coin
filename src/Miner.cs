using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LuckyCoin.src
{
    // TODO
    /*
     could maybe avoid byte conversion to string and vice versa
     */
    public class Miner 
    {
        public Miner()
        {
        }

        public byte[] MineBlock(Block blockToMine)
        {
            var blockHeader = blockToMine.BlockHeader;
            var difficulty = blockToMine.BlockHeader.DifficultyTarget;

            byte[] hash = blockHeader.CalculateBlockHash();
            string blockHash = Helper.HashToString(hash).Split('x')[1];

            string target = new String('0', difficulty);

            while (blockHash.Substring(0, difficulty) != target)
            {
                blockHeader.Nonce += 1;
                blockHash = Helper.HashToString(blockHeader.CalculateBlockHash()).Split('x')[1];
            }

            return Helper.StringToByteArray(blockHash);
        }
    }
}
