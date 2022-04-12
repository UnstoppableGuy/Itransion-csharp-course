using System;
using System.Security.Cryptography;


namespace solution3
{
    class HMACGenerator
    {
        
        private byte[] _key;
        private byte[] _HMAChash;

        public HMACGenerator(byte[] inputBytes, int keyByteSize)
        { 
            _key = GenerationKey(keyByteSize);
            _HMAChash = FindHMAC(inputBytes,_key);
        }

        private static byte[] GenerationKey(int ByteSize)
        {
            byte[] _key = new byte[ByteSize];
            RandomNumberGenerator.Create().GetBytes(_key, 0, ByteSize);
            return _key;
        }

        private static byte[] FindHMAC(byte[] input, byte[] _key)
        {
            var HMACGenerator = new HMACSHA256(_key);
            byte[] bhash = HMACGenerator.ComputeHash(input);
            return bhash;
        }

        public void OutputKey()
        {
            string keyStr = BitConverter.ToString(_key).Replace("-", string.Empty);
            Console.WriteLine($"HMACGenerator _key: {keyStr}");
        }

        public void OutputHMAC()
        {
            string hmacStr = BitConverter.ToString(_HMAChash).Replace("-", string.Empty);
            Console.WriteLine($"HMACGenerator: {hmacStr}");
        }

    }
}
