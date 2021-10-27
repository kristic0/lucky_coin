using System.Collections.Generic;

namespace LuckyCoin.src
{
    public class Block
    {
        private BlockHeader _blockHeader;
        private int _blocksize;
        private int _txCounter;
        private List<Transaction> _transactions;

        public List<Transaction> Transactions { get => _transactions; set => _transactions = value; }
        public BlockHeader BlockHeader { get => _blockHeader; set => _blockHeader = value; }
        public int TxBlockLimit { get; set; }

        public Block()
        {
            TxBlockLimit = 100;
            _transactions = new List<Transaction>();
        }

        public void SetBlockHash(byte[] hash)
        {
            _blockHeader.HashOfBlock = hash;
        }

        public void AddTransactionToBlock(Transaction tx)
        {
            _transactions.Add(tx);
        }

        public void CreateHeader()
        {
            _blockHeader = new BlockHeader(_transactions);
        }
    }
}
  