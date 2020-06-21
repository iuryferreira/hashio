using System.Security.Cryptography;

namespace Hash
{
    /// <summary>
    /// The Hasher options class.
    /// Contains all options for configure your Hasher and customize as your prefer.
    /// Only use when you need to customize some of the algorithm's options.
    /// </summary>
    public sealed class HashingOptions
    {
        private int iterations = 10000;
        private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
        private int saltSize = 16;
        private int keySize = 32;

        public int Iterations { get => iterations; set => iterations = value; }
        public HashAlgorithmName HashAlgorithm { get => hashAlgorithm; set => hashAlgorithm = value; }
        public int SaltSize { get => saltSize; set => saltSize = value; }
        public int KeySize { get => keySize; set => keySize = value; }
    }
}