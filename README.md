<p align="center">
  <img alt="Authentication" title="Authentication" src=".github/images/hashio.png" width="400px" />
</p>
<h3 align="center">
    Uma biblioteca para fazer hash de senhas no .NET Core
</h3>

<p align="center">
  <img alt="GitHub language count" src="https://img.shields.io/badge/language-1-blue">

  <a href="">
    <img alt="Made by Iury Ferreira" src="https://img.shields.io/badge/made%20by-Iury%20Ferreira-blue">
  </a>

  <img alt="License" src="https://img.shields.io/badge/license-MIT-blue">

### ✌ Hello!

Hashio é uma biblioteca C # para criptografar strings, comumente usada para proteger senhas de usuários. Esta implementação usa o algoritmo PBKDF2 para realizar a criptografia, e você pode encontrar mais detalhes sobre isso na documentação oficial disponível [aqui](https://tools.ietf.org/html/rfc2898#section-5.2). Esta implementação é uma abstração baseada na implementação disponibilizada pela Microsoft [aqui](https://docs.microsoft.com/pt-br/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-3.1).

### 🛠 Instalação

  Use os meios de instalação abaixo.

  #### CLI (Linux/Windows/Mac)
Para instalar pela linha de comando (CLI), basta executar o seguinte comando na pasta do projeto:

  ```bash 
    dotnet add package Hashio
  ```
  #### Gerenciador de Pacotes NuGet (Windows/Mac)
  
Basta pesquisar "Hashio" em seu Visual Studio e clicar em adicionar pacote.

### 💻 Uso

Existem dois caminhos para utilizar o Hashio:  Usando com as  ***Configurações Padrão*** ou definindo as suas, caso deseje.

#### Usando as configurações padrão (Recomendado)

Para usar o Hashio rapidamente e sem configurações adicionais, basta utilizar a class `Hasher`  e chamar os métodos que você precisa, como por exemplo:

  ```csharp 

    string password = "HashioIsAwesome!";
    
    // Gerando um hash de senha
    string hash = Hasher.Hash(password);

    // Verificar se a senha informada é a senha hash gerada.
    bool validate = Hasher.Check(hash, password);
  ```
Por padrão, as seguintes configurações são definidas:

  - Iterations =  10000;
  - Hash Algorithm =  SHA256;
  - Key Size = 32;
  - Mininum Salt Size = 32;
  - Maximum Salt Size = 32;


#### Usando configurações personalizadas

Se necessário, você também pode personalizar as configurações por meio do método `WithOptions` da classe `Hasher`. Ele recebe um objeto da classe ```HashingOptions``` e permite que você altere:

1. Number of Iterations
2. Hash Algorithm
3. Salt Size
4. Mininum Salt Size
5. Maximum Salt Size

    💡 Você também precisará usar a classe ```System.Security.Cryptography.HashAlgorithmName``` para escolher um algoritmo de hash.

Abaixo está um exemplo de como usá-lo:
 
```csharp
  var hashOptions = new HashingOptions
  {
    Iterations = 10000,
    HashAlgorithm = System.Security.Cryptography.HashAlgorithmName.SHA512, // Mudou de 256 para 512
    MinSaltSize = 16, // Mudou de 32 para 16
    MaxSaltSize = 64, // Mudou de 32 para 64
    KeySize = 64, // Mudou de 32 para 64
  };

  // Você passa as opções como parâmetro para o método WithOptions
  Hasher.WithOptions(hashOptions);
  
```
Qualquer problema, dúvida ou sugestão, abra como um problema e eu responderei assim que tiver tempo. 😅