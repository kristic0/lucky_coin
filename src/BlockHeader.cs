using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using LuckyCoin.src.Merkle;

namespace LuckyCoin.src
{
    public class BlockHeader
    {
        public byte[] HashPrevBlock { get; set; }
        public byte[] HashMerkleRoot { get; set; }
        public int DifficultyTarget { get; set; }
        public ulong Nonce { get; set; }
        public byte[] HashOfBlock { get; set; }
        public long TimeStamp { get; set; }
        public int Reward { get; }

        public BlockHeader(List<Transaction> txs)
        {
            MerkleTree merkleTree = new MerkleTree(txs);
            HashMerkleRoot = merkleTree.CalculateMerkleRoot();
            DifficultyTarget = 5;
            Nonce = 0;
            Reward = 50;
        }

    }
}
