using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace LuckyCoin.src.MerkleTree
{
    class MerkleTree
    {
        private List<Transaction> _txList;

        public MerkleTree(List<Transaction> txList)
        {
            _txList = txList;
        }

        public void CalculateMerkleRoot()
        {
            List<byte[]> hashes = new List<byte[]>();

            for (int i = 1; i < _txList.Count; i+= 2)
            {

                hashes.Add(
                    SHA256
                    .Create()
                    .ComputeHash(Encoding.UTF8.GetBytes(SerializeHashes(_txList[i - 1].Hash, _txList[i].Hash))));
            }

            //foreach (var hash in hashes)
            //{
            //    Console.WriteLine(Helper.HashToString(hash));
            //}
        }

        public string SerializeHashes(byte[] arg1, byte[] arg2)
        {
            string jsonArgs = JsonSerializer.Serialize(new { arg1, arg2 });

            //Console.WriteLine(jsonArgs);

            return jsonArgs;
        }
    }
}
