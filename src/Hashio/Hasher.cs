using System;
using System.Linq;
using System.Security.Cryptography;
using Hashio.Models;

namespace Hashio
{
    /// <summary>
    /// The main Hasher class.
    /// Contains all methods for performing hashing and checking functions.
    /// </summary>
    public static class Hasher
    {
        /// <summary>
        ///Options for string encryption.
        /// </summary>
        public static HashingOptions Options { get; private set; } = new();

        ///<summary>
        ///Generates a hash of the supplied value using the PBKDF2 algorithm (RFC 2898). Is returned a hash generated from the value provided as a parameter.
        ///</summary>
        /// <param name="value">String that will be encrypted based on the defined settings.</param>
        /// <exception cref="ArgumentNullException">
        ///     The exception is thrown when a null or empty
        ///     value is passed to the method that does not allow this operation.
        /// </exception>
        public static string Hash (string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("You cannot generate a hash of an empty or null string.");
            }

            var saltSize = new Random().Next(Options.MinSaltSize, Options.KeySize);
            var algorithm = new Rfc2898DeriveBytes(value, saltSize, Options.Iterations, Options.HashAlgorithm);
            var key = Convert.ToBase64String(algorithm.GetBytes(Options.KeySize));
            var salt = Convert.ToBase64String(algorithm.Salt);
            return $"{salt}.{Options.Iterations}.{key}";
        }

        /// <summary>
        ///Checks if the password provided is the same as the previously generated hash that is also provided in the parameters.
        /// </summary>
        /// <param name="hash">Received non-empty hash string that will be used for comparison.</param>
        /// <param name="value">String to compare with hash</param>
        /// <exception cref="ArgumentNullException">
        ///     The exception is thrown when a null or empty
        ///     value is passed to the method that does not allow this operation.
        /// </exception>
        public static bool Check (string hash, string value)
        {
            if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The hash and value to be compared cannot be null or empty.");
            }

            Hash hashObject = new Hash(hash);
            var algorithm = new Rfc2898DeriveBytes(value, hashObject.Salt, hashObject.Iterations, Options.HashAlgorithm);
            var keyToCheck = algorithm.GetBytes(Options.KeySize);
            return keyToCheck.SequenceEqual(hashObject.Key);
        }

        /// <summary>
        ///Set custom options for string encryption.
        /// </summary>
        /// <param name="options">Options object to define which settings the hashers should operate with.</param>
        /// <exception cref="ArgumentNullException">
        ///     The exception is thrown when a null
        ///     value is passed to the method that does not allow this operation.
        /// </exception>
        public static void WithOptions (HashingOptions options)
        {

            if (options == null)
            {
                throw new ArgumentNullException("The options informed cannot be null.");
            }

            if (options.MinSaltSize > options.MaxSaltSize)
            {
                throw new ArgumentNullException("The minimum salt must be less than the maximum.");
            }

            Options = options;
        }
    }
}
