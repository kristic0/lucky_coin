using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyCoin.src
{
    class BlockHeader
    {
        private string _hashPrevBlock;
        private string _hashMerkleRoot;                // curr block hash
        private long _timeStamp;
        private string _difficultyTarget;
        private string _nonce;
        // private string version;

        public string HashPrevBlock
        {
            get => _hashPrevBlock;
            set => _hashPrevBlock = value;
        }

        public BlockHeader()
        {
            _timeStamp = DateTimeOffset.Now.ToUnixTimeSeconds();

        }
    }
}
