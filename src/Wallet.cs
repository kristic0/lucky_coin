using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LuckyCoin
{
    public class WalletData
    {
        
    }
    
    public class Wallet
    {
        public Wallet(string passphrase, byte[] privateKey)
        {
            // generate wallet address from passphrase and priv_key
        }
        
        public Wallet(string passphrase)
        {
            var pathToWalletFile = AppDomain.CurrentDomain.BaseDirectory + "/Wallet/wallet.json";
            
            // generate wallet address from passphrase and priv_key
            WriteWalletToDisk(pathToWalletFile);
            LoadWalletFromDisk(pathToWalletFile);
        }

        private async void WriteWalletToDisk(string pathToWalletFile)
        {
            // name file as pub key
            var data = JsonConvert.SerializeObject(
                new
                {
                    data = 11,
                    arr = new
                    {
                        dataInside = 2121
                    }
                });
            
            string dir = AppDomain.CurrentDomain.BaseDirectory + @"/Wallet";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            
            //await using FileStream createStream = File.Create(pathToWalletFile);
            //await JsonSerializer.SerializeAsync(createStream, data);
            
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            await using StreamWriter sw = new StreamWriter(pathToWalletFile);
            using JsonWriter writer = new JsonTextWriter(sw);
            serializer.Serialize(writer, data);
        }

        private void LoadWalletFromDisk(string pathToWalletFile)
        {
            using StreamReader sr = new StreamReader(pathToWalletFile);
            string json = sr.ReadToEnd();
            dynamic array = JsonConvert.DeserializeObject(json);
            Console.WriteLine(array);
        }

        public void CalculateBalance()
        {
            // go through all txs for this specific addr
            // and return current balance based on UTXO
        }
        
        
    }
}