using System;
using System.Linq;
using System.Security.Cryptography;
using Hash.Interfaces;
using Hash.Models;

namespace Hash
{

    /// <summary>
    /// The main Hashio class.
    /// Contains all methods for performing hashing and checking functions.
    /// </summary>
    public sealed class Hashio : IHashio
    {
        private HashingOptions Options { get; }

        public Hashio () => Options = new HashingOptions();

        public Hashio (HashingOptions options) => Options = options;
        ///<summary>
        ///Generates a hash of the supplied value using the PBKDF2 algorithm (RFC 2898). Is returned a hash generated from the value provided as a parameter.
        ///</summary>
        public string Hash (string value)
        {
            Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(value, Options.SaltSize, Options.Iterations, Options.HashAlgorithm);
            string key = Convert.ToBase64String(algorithm.GetBytes(Options.KeySize));
            string salt = Convert.ToBase64String(algorithm.Salt);

            return $"{salt}.{Options.Iterations}.{key}";
        }
        /// <summary>
        ///Checks if the password provided is the same as the previously generated hash that is also provided in the parameters.
        /// </summary>
        public bool Check (string hash, string value)
        {
            HashObject hashObject = new HashObject(hash);
            Rfc2898DeriveBytes algorithm = new Rfc2898DeriveBytes(value, hashObject.Salt, hashObject.Iterations, Options.HashAlgorithm);
            var keyToCheck = algorithm.GetBytes(Options.KeySize);

            return keyToCheck.SequenceEqual(hashObject.Key);
        }
    }
}