# Criando o ambiente de desenvolvimento

 - Primeiro passo, caso não tenha a SDK do .NET Core instalada, é baixar no site da Microsoft pelo link https://dotnet.microsoft.com/download/dotnet/.

 - Após instalado, vamos criar o ambiente de desenvolvimento. Pode usar o Visual Studio ou Visual Studio Code como IDE, no meu caso prefiro o Visual Studio Code por já usá-lo em outras linguagens de programação. 
    Observação: Se optar por usar Visual Studio Code certifique-se de ter instalado a extensão para linguagem C#.

 - Crie a pasta onde ficará o projeto e utilize o PowerShell (caso utilize Windows) e vá até a pasta do projeto criada, execute o comando “code . “ para abrir o VS Code já com sua pasta de projeto aberta.

 - Abra o terminal do VS Code e execute o comando “dotnet new web –o nomedoprojeto” no meu caso o projeto chama backendcard. Feito isso será criado o projeto .NET e seus arquivos essenciais.

 - Ainda no terminal vamos executar comandos para adicionar pacotes que serão necessarios no projeto. O primeiro é o Entity Framework com o comando “dotnet add package Microsoft.EntityFrameworkCore” e o segundo é o InMemory com o comando “dotnet add package Microsoft.EntityFrameworkCore.InMemory”. O Entity Framework é um ORM, assim ele abstrai a camada de comunicação com o banco de dados tornando o aplicativo flexivel em termos de banco de dados. O InMemory é para usarmos um “banco de dados” na memória já que não temos ainda definido um banco de dados a ser utilizado.
 
Feito estes passos o ambiente de desenvolvimento foi criado.
![Ambiente criado](/img/ambientedev.png)

# Criando as classes principais

 - Seguindo a arquitetura MVC vamos criar o Model e o Controller. Crie 2 novas pastas no projeto, uma com nome de “Models” e  outra “Controllers”. Usando o MVC vamos separar as classes por suas funcionalidades. Na pasta Models crie um arquivo que conterá a classe de dados da api. No meu caso dei o nome de “Card.cs”, dentro do arquivo defina o namespace e crie a classe dos dados referente aos cartões que serão gerados. Veja na imagem como fiz.
![Model](/img/model.png)  
IMAGEM
Poderia ser feito sem o atributo Id, porem resolvi deixar um indentificador único para cada registro.

 - Agora vamos criar o arquivo “CardController.cs” na pasta Controllers, nele estarão as regras de negócio da api.
Após definir o namespace foi definido algumas caracteristicas. Primeiro a propriedade ApiController para trabalhar com http requests e a rota para esse controller. A classe herdamos de ControllerBase. Dentro da rota definida como “card” vamos criar 2 http requests, um get para receber os dados do cartão criado e um post para criar os dados do cartão.
IMAGEM
![Controller](/img/cardcontroller.png)



