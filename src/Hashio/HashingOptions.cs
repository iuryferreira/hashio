using System;
using System.Security.Cryptography;

namespace Hashio
{
    /// <summary>
    /// The Hasher options class.
    /// Contains all options for configure your Hasher and customize as your prefer.
    /// </summary>
    public sealed class HashingOptions
    {
        public int Iterations { get; init; } = 10000;
        public int KeySize { get; init; } = 32;
        public int MinSaltSize { get; init; } = 32;
        public int MaxSaltSize { get; init; } = 32;
        public HashAlgorithmName HashAlgorithm { get; init; } = HashAlgorithmName.SHA256;
    }
}
