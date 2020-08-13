using System;

namespace Hash.Models
{
    ///<summary>
    /// This class creates a hash object that is used when checking the hash.
    ///</summary>
    class HashObject
    {
        int iterations;
        byte[] key;
        byte[] salt;

        public int Iterations { get => iterations; set => iterations = value; }
        public byte[] Key { get => key; set => key = value; }
        public byte[] Salt { get => salt; set => salt = value; }

        public HashObject (string hash)
        {
            var parts = hash.Split('.', 3);
            Salt = Convert.FromBase64String(parts[0]);
            Iterations = Convert.ToInt32(parts[1]);
            Key = Convert.FromBase64String(parts[2]);
        }
    }
}