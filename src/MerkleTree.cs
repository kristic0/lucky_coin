﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LuckyCoin.src.Merkle
{
    class MerkleTree
    {
        private readonly List<Transaction> _txList;

        public MerkleTree(List<Transaction> txList)
        {
            _txList = txList;
        }

        public byte[] CalculateMerkleRoot()
        {
            // After all the cycles hashes[0] becomes the root, 
            // until then it's just storing the current cycle
            
            if(_txList.Count == 1)
            {
                return _txList[0].Hash;
            }

            var hashes = new List<byte[]>();
            var tempHashes = new List<byte[]>();

            foreach(var tx in _txList)
            {
                tempHashes.Add(tx.Hash);
            }

            // -1 because the first round is actually found in the tx itself
            for (int i = 0; i < Math.Ceiling((decimal)_txList.Count / 2) - 1; i++)
            {
                if (i != 0) 
                {
                    tempHashes.Clear();
                    tempHashes = new List<byte[]>(hashes);
                    hashes.Clear();
                }

                Compute(tempHashes, hashes);
            }

            //Console.WriteLine("Merkle root is: " + Helper.HashToString(hashes[0]));
            
            return hashes[0];
        }

        private void Compute(List<byte[]> tempHashes, List<byte[]> hashes)
        {
            var toSerialize = new List<byte[]>();
            for (int i = 0; i < tempHashes.Count; i += 2)
            {
                if (i + 1 < tempHashes.Count)
                {
                    toSerialize.Add(tempHashes[i]);
                    toSerialize.Add(tempHashes[i + 1]);

                    hashes.Add(
                        SHA256
                        .Create()
                        .ComputeHash(Encoding.UTF8.GetBytes(SerializeHashes(toSerialize))));
                }
                else
                {
                    hashes.Add(tempHashes[i]);
                }

                toSerialize.Clear();
            }

            //foreach (var hash in hashes)
            //{
            //    Console.WriteLine(Helper.HashToString(hash));
            //}
        }

        private string SerializeHashes(List<byte[]> hash)
        {
            var serializedHashes = new StringBuilder();
            serializedHashes.Append("[");

            for (int i = 0; i < hash.Count; i += 2)
            {
                serializedHashes.Append(Helper.ByteArrToString(hash[i]));                
                serializedHashes.Append(", ");
                serializedHashes.Append(Helper.ByteArrToString(hash[i + 1]));
                serializedHashes.Append("]");
            }

            // Console.WriteLine(serializedHashes + "\n");
            
            return serializedHashes.ToString();
        }
    }
}
