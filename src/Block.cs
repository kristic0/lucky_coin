using System.Collections.Generic;

namespace LuckyCoin.src
{
    public class Block
    {
        private BlockHeader _blockHeader;
        private int _blocksize;
        private int _txCounter;
        private int _txBlockLimit;
        private List<Transaction> _transactions;

        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }
        public BlockHeader BlockHeader { get => _blockHeader; set => _blockHeader = value; }

        public Block(byte[] hashPrevBlock)
        {
            _txBlockLimit = 100;
            _transactions = new List<Transaction>();
            _transactions = Helper.PopulateFakeTx(); // todo remove after proper impl

            _blockHeader = new BlockHeader(_transactions);
            _blockHeader.HashPrevBlock = hashPrevBlock;

            _txCounter = _transactions.Count;
        }
    }
}
  