<p align="center">
  <img alt="Authentication" title="Authentication" src=".github/images/hasher.png" width="400px" />
</p>
<h3 align="center">
    A simple library for hashing passwords in .NET Core
</h3>

<p align="center">
  <img alt="GitHub language count" src="https://img.shields.io/badge/language-1-blue">

  <a href="">
    <img alt="Made by Iury Ferreira" src="https://img.shields.io/badge/made%20by-Iury%20Ferreira-blue">
  </a>

  <img alt="License" src="https://img.shields.io/badge/license-MIT-blue">

### ✌ Hello!

Hashio is a C # library for encrypting strings, commonly used to protect user passwords. This implementation uses the PBKDF2 algorithm to perform encryption, and you can find more details about it in the official documentation available [here](https://tools.ietf.org/html/rfc2898#section-5.2). This implementation is an abstraction based on the implementation made available by Microsoft [here](https://docs.microsoft.com/pt-br/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.1).

### 🛠 Install

  Use the installation means below.

  #### CLI (Linux/Windows/Mac)
  To install via the command line (CLI), just run the following command in your project folder:

  ```bash 
    dotnet add package Hashio
  ```
  #### NuGet packages Manager (Windows/Mac)
  
  Just search for "Hashio" in your Visual Studio and click on add package.


### 💻 Usage

There are two ways to use Hashio: using the ***Default Settings*** or defining your own, if you wish.

#### Using the Default Settings (Recommend)

To use Hashio quickly and without additional settings, just instantiate it and call the methods you need, such as:

  ```csharp 
    var hashio = new Hashio();

    string password = "HashioIsAwesome!";
    
    // Generating a password hash

    string hash = hashio.Hash(password);

    // Checking if the password is the generated hash password.

    bool validate = hashio.Check(hash, password);
  ```
By default, the following settings are configured:

  - Iterations =  10000;
  - Hash Algorithm =  SHA256;
  - Salt Size = 16;
  - Key Size = 32;


#### Using Custom Settings

If you need to, you can also customize the settings through the ```HashingOptions``` class. It allows you to change:

1. Number of Iterations
2. Hash Algorithm
3. Salt Size
4. Key Size

    💡 You will also need to use the built-in ```System.Security.Cryptography.HashAlgorithmName``` to choose a hashing algorithm.

Below is an example of how to use it:
 
```csharp
  var hashOptions = new HashingOptions
  {
    Iterations = 10000,
    HashAlgorithm = System.Security.Cryptography.HashAlgorithmName.SHA512, // Changed from 256 to 512
    SaltSize = 16,
    KeySize = 64, //Changed from 32 to 64
  };

  // You pass the options as parameter of the instance of Hashio
  var hashio = new Hashio(hashOptions);
```
Any problem, question or suggestion, open it as an issue and I will reply as soon as I have time. 😅

### :memo: License

MIT Licence. See the file [LICENSE](LICENSE.md) for more details.

If you have some problem with the documentation, just send a pull request that i'll be happy to help. 😃

Made with 💻 by Iury :wave: [See my linkedin!](https://www.linkedin.com/in/iury-ferreira-68ba35130/)
