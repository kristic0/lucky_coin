using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using LuckyCoin.src.Merkle;

namespace LuckyCoin.src
{
    public class BlockHeader
    {
        private byte[] _hashOfBlock;
        private byte[] _hashPrevBlock;
        private byte[] _hashMerkleRoot;
        private long _timeStamp;
        private int _difficultyTarget;
        private ulong _nonce;
        // private string version;

        public byte[] HashPrevBlock { get => _hashPrevBlock; set => _hashPrevBlock = value; }
        public byte[] HashMerkleRoot { get => _hashMerkleRoot; set => _hashMerkleRoot = value; }
        public int DifficultyTarget { get => _difficultyTarget; }
        public ulong Nonce { get => _nonce; set => _nonce = value; }
        public byte[] HashOfBlock { get => _hashOfBlock; set => _hashOfBlock = value; }

        public BlockHeader(List<Transaction> txs)
        {
            MerkleTree merkleTree = new MerkleTree(txs);

            _hashMerkleRoot = merkleTree.CalculateMerkleRoot();
            _difficultyTarget = 4;
            _nonce = 0;
        }

        public byte[] CalculateBlockHash()
        { 
            _timeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();

            if(_hashPrevBlock == null)
            {
                _hashPrevBlock = new byte[0];
            }

            byte[] hash = SHA256.Create().ComputeHash(
                _hashPrevBlock
                .Concat(_hashMerkleRoot)
                .Concat(BitConverter.GetBytes(_nonce))
                .Concat(BitConverter.GetBytes(_timeStamp))
                .ToArray());

            //Console.WriteLine(Helper.HashToString(hash) + '\n');

            return hash;
        }
    }
}
