using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LuckyCoin.src
{
    public class Block
    {
        private BlockHeader _blockHeader;
        private int _blocksize;
        private long _txCounter;
        private List<Transaction> _transactions;

        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set { _transactions = value; }
        }

        public Block(string hashPrevBlock)
        {
            _blockHeader = new BlockHeader();
            _blockHeader.HashPrevBlock = hashPrevBlock;
            _transactions = new List<Transaction>();

            Transactions = Helper.PopulateFakeTx(); // todo remove after proper impl
        }

        public string ReadFromBlock()
        {
            return $"{_blockHeader.HashPrevBlock.ToString()}";
        }

        private void CalculateMerkleRoot()
        {

        }


    }
}
