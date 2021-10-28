using System.Collections.Generic;

namespace LuckyCoin.src
{
    public class Block
    {
        //private int _blocksize;

        public List<Transaction> Transactions { get ; set ; }
        public BlockHeader BlockHeader { get ; set; }
        public int TxBlockLimit { get; set; }
        private int TxCounter { get; set; }
        

        public Block()
        {
            TxBlockLimit = 100;
            TxCounter = 0;
            Transactions = new List<Transaction>();
        }

        public void SetBlockHash(byte[] hash)
        {
            BlockHeader.HashOfBlock = hash;
        }

        public void AddTransactionToBlock(Transaction tx)
        {
            Transactions.Add(tx);
            TxCounter += 1;
        }

        public void CreateHeader() // could be called in constructor -maybe
        {
            BlockHeader = new BlockHeader(Transactions);
        }

        public void GenerateCoinbaseTx()
        {
            var tx = new Transaction
            {
                Inputs = null,
                Outputs = new List<TxOut>
                {
                    new TxOut
                    {
                        Amount = 50,
                        RecipientAddr = ""
                    }
                }
            };
            Transactions.Add(tx);
        }
    }
}
  