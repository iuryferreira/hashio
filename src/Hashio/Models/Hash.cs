using System;

namespace Hashio.Models
{
    internal class Hash
    {
        ///<summary>
        /// This class creates a hash object that is used when checking the hash.
        ///</summary>
        public Hash (string hash)
        {
            var parts = hash.Split('.', 3);
            Salt = Convert.FromBase64String(parts[0]);
            Iterations = Convert.ToInt32(parts[1]);
            Key = Convert.FromBase64String(parts[2]);
        }
        
        public int Iterations { get; }
        public byte[] Key { get; }
        public byte[] Salt { get; }
    }
}
