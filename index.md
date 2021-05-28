# Criando o ambiente de desenvolvimento

 - Primeiro passo, caso não tenha a SDK do .NET Core instalada, é baixar no site da Microsoft pelo link https://dotnet.microsoft.com/download/dotnet/.
 - Após instalado, vamos criar o ambiente de desenvolvimento. Pode usar o Visual Studio ou Visual Studio Code como IDE, no meu caso prefiro o Visual Studio Code por já usá-lo em outras linguagens de programação. 
Observação: Se optar por usar Visual Studio Code certifique-se de ter instalado a extensão para linguagem C#.
Crie a pasta onde ficará o projeto e utilize o PowerShell(Caso utilize Windows) e vá até a pasta do projeto criada, execute o comando “code . “ para abrir o VS Code já com sua pasta de projeto aberta.
Abra o terminal do VS Code e execute o comando “dotnet new web –o nomedoprojeto” no meu caso o projeto chama backendcard. Feito isso será criado o projeto .NET e seus arquivos essenciais.
Ainda no terminal vamos executar comandos para adicionar pacotes que serão necessarios no projeto. O primeiro é o Entity Framework com o comando “dotnet add package Microsoft.EntityFrameworkCore” e o segundo é o InMemory com o comando “dotnet add package Microsoft.EntityFrameworkCore.InMemory”. O Entity Framework é um ORM, assim ele abstrai a camada de comunicação com o banco de dados tornando o aplicativo flexivel em termos de banco de dados. O InMemory é para usarmos um “banco de dados” na memória já que não temos ainda definido um banco de dados a ser utilizado.
Feito estes passos o ambiente de desenvolvimento foi criado.

