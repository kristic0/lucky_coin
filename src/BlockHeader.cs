using System;
using System.Collections.Generic;
using LuckyCoin.src.Merkle;

namespace LuckyCoin.src
{
    public class BlockHeader
    {
        private byte[] _hashOfBlock;
        private byte[] _hashPrevBlock;
        private byte[] _hashMerkleRoot;
        private long _timeStamp;
        private string _difficultyTarget;
        private string _nonce;
        // private string version;

        public byte[] HashPrevBlock
        {
            get => _hashPrevBlock;
            set => _hashPrevBlock = value;
        }
        public byte[] HashMerkleRoot 
        { 
            get => _hashMerkleRoot; 
            set => _hashMerkleRoot = value; 
        }

        public BlockHeader(List<Transaction> txs)
        {
            _timeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();

            MerkleTree merkleTree = new MerkleTree(txs);
            _hashMerkleRoot = merkleTree.CalculateMerkleRoot();
        }
    }
}
