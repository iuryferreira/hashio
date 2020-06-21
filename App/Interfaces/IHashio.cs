namespace Hash.Interfaces
{
    /// <summary>
    /// The contract to Hashio class.
    /// Contains all methods for performing hashing and checking functions.
    /// </summary>
    public interface IHashio
    {
        public string Hash (string value);
        public bool Check (string hash, string value);
    }
}