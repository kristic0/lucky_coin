using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace LuckyCoin.src
{
    // TODO
    /*
     could maybe avoid byte conversion to string and vice versa in MineBlock
     */

    public static class MyExtensions
    {
        public static void SetPrevHashFor(this List<Block> list, Block item)
        {
            if(list.Count - 1 > 0)
            {
                var hashOfPrevBlock = list.ElementAt(list.Count - 2).BlockHeader.HashOfBlock;
                item.BlockHeader.HashPrevBlock = hashOfPrevBlock;
            }
        }
    }

    public class Miner 
    {
        public Miner(List<Block> chain, TransactionPool txPool)
        {
            while(true)
            {
               // Console.WriteLine("Mining block no: " + chain.Count);

                if (txPool.Transactions.Count > 0)
                {
                    Block block = new Block();

                    for (int i = 0; i < block.TxBlockLimit; i++)
                    {
                        var tx = txPool.Transactions.Dequeue();
                        block.AddTransactionToBlock(tx);
                    }

                    block.CreateHeader();
                    MineBlock(block);

                    chain.Add(block);
                    chain.SetPrevHashFor(block);

                    Console.WriteLine(Helper.ByteArrToString(block.BlockHeader.HashPrevBlock));
                    Console.WriteLine(Helper.ByteArrToString(block.BlockHeader.HashOfBlock));
                } else
                {
                    Thread.Sleep(5000);
                }
            }
        }

        public void MineBlock(Block blockToMine)
        {
            string blockHash;
            byte[] hash;

            var blockHeader = blockToMine.BlockHeader;
            var difficulty = blockToMine.BlockHeader.DifficultyTarget;

            string target = new String('0', difficulty);

            do
            {
                hash = CalculateBlockHash(blockToMine);
                blockHeader.Nonce += 1;
                blockHeader.TimeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();
                blockHash = Helper.ByteArrToString(hash).Split('x')[1];

            } while (blockHash.Substring(0, difficulty) != target);

            blockToMine.SetBlockHash(hash);
        }

        public byte[] CalculateBlockHash(Block block)
        {
            var hashMerkleRoot = block.BlockHeader.HashMerkleRoot;
            var timeStamp = block.BlockHeader.TimeStamp;
            var nonce = block.BlockHeader.Nonce;

            if (block.BlockHeader.HashPrevBlock == null)
            {
                block.BlockHeader.HashPrevBlock = new byte[32];
            }

            byte[] hash = SHA256.Create().ComputeHash(
                hashMerkleRoot
                .Concat(block.BlockHeader.HashPrevBlock)
                .Concat(BitConverter.GetBytes(nonce))
                .Concat(BitConverter.GetBytes(timeStamp))
                .ToArray());

            return hash;
        }
    }
}
