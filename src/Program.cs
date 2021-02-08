using LuckyCoin.src;
using LuckyCoin.src.MerkleTree;
using System;
using System.Collections.Generic;

namespace LuckyCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            // BlockChain blockChain = new BlockChain();

            List<Transaction> tList = new List<Transaction>();
            tList = Helper.PopulateFakeTx();
            MerkleTree mt = new MerkleTree(tList);
            mt.CalculateMerkleRoot();
        }
    }
}
