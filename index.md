# Criando o ambiente de desenvolvimento

 - Primeiro passo, caso não tenha a SDK do .NET Core instalada, é baixar no site da Microsoft pelo link https://dotnet.microsoft.com/download/dotnet/.

 - Após instalado, vamos criar o ambiente de desenvolvimento. Pode usar o Visual Studio ou Visual Studio Code como IDE, no meu caso prefiro o Visual Studio Code por já usá-lo em outras linguagens de programação. 
    * Observação: Se optar por usar Visual Studio Code certifique-se de ter instalado a extensão para linguagem C#.

 - Crie a pasta onde ficará o projeto e utilize o PowerShell (caso utilize Windows) e vá até a pasta do projeto criada, execute o comando “code . “ para abrir o VS Code já com sua pasta de projeto aberta.

 - Abra o terminal do VS Code e execute o comando “dotnet new web –o nomedoprojeto” no meu caso o projeto chama backendcard. Feito isso será criado o projeto .NET e seus arquivos essenciais.

 - Ainda no terminal vamos executar comandos para adicionar pacotes que serão necessarios no projeto. O primeiro é o Entity Framework com o comando “dotnet add package Microsoft.EntityFrameworkCore” e o segundo é o InMemory com o comando “dotnet add package Microsoft.EntityFrameworkCore.InMemory”. O Entity Framework é um ORM, assim ele abstrai a camada de comunicação com o banco de dados tornando o aplicativo flexivel em termos de banco de dados. O InMemory é para usarmos um “banco de dados” na memória já que não temos ainda definido um banco de dados a ser utilizado.
 
Feito estes passos o ambiente de desenvolvimento foi criado.

 ![Ambiente criado](/img/ambientedev.png)


# Criando as classes principais

 - Seguindo a arquitetura MVC vamos criar o Model e o Controller. Crie 2 novas pastas no projeto, uma com nome de “Models” e  outra “Controllers”. Usando o MVC vamos separar as classes por suas funcionalidades. Na pasta Models crie um arquivo que conterá a classe de dados da api. No meu caso dei o nome de “Card.cs”, dentro do arquivo defina o namespace e crie a classe dos dados referente aos cartões que serão gerados. Veja na imagem como fiz.

 ![Model](/img/model.png)  

    * Observação: Poderia ser feito sem o atributo Id, porem resolvi deixar um indentificador único para cada registro.

 - Agora vamos criar o arquivo “CardController.cs” na pasta Controllers, nele estarão as regras de negócio da api.
Após definir o namespace foi definido algumas caracteristicas. Primeiro a propriedade ApiController para trabalhar com http requests e a rota para esse controller. A classe herdamos de ControllerBase. Dentro da rota definida como “card” vamos criar 2 http requests, um get para receber os dados do cartão criado e um post para criar os dados do cartão.

 ![Controller](/img/cardcontroller.png)


# Criando um repositório e o DbContext
 - Por hora deixaremos as classes de model e controller e vamos criar uma pasta “Repository” onde usaremos para criar um DataContext que herda DbContext do Entity Framework, que será responsável por carregar nosso banco de dados através do DataContextOptions que será definido mais adiante no arquivo Startup.cs e o DbSet que pegará nosso objeto Card e persistir no banco por encapsulamento do Entity Framework. Usaremos também um repositório de regras de negocios chamado CardRepository para melhorar a organização e independência do código.
 
 ![DataContext](/img/DataContext.png)


# CardRepository

 - Após criar a pasta Repository, crie dentro dela o arquivo CardRepository.cs. Nesse arquivo criaremos uma Interface que fará a comunicação com o controller. Criaremos 2 métodos para um CRUD parcial, uma para criação do cartão e outro para a leitura dos cartões criados. Aqui também criaremos um contrutor de DataContext para ligar a camada de dados com o controller. 

 ![Interface](/img/cardrepository1.png)

 - Em Create será gerado os números aleatórios do novo cartão de crédito, receber o email de um json passado pelo post e salvar no banco de dados criado na memória. Será retornado os dados salvos.

 - Em Read receberemos o email por parametro através do endpoint definido em Startup.cs. Se o email estiver vinculado a algum cartão criado, ele retornará  uma lista de objetos Card com os cartões vinculados ao email passado no parametro.

 ![Create / Read](/img/cardrepository2.png)


# Configurando arquivo Startup.cs

 - Abra o arquivo Startup.cs para configurar os serviços e endponints da api. 

 - Adicionaremos os serviços que faz a comunicação com InMemory, nosso banco de dados virtual, e o serviço que fará a ligação entre o repositorio com o controller.

 - Adicionaremos também as configurações de endpoint definindo que Controller que irá mapear os endponits.

 ![Startup.cs](/img/startup.png)


# GET e POST

 - Voltando ao arquivo CardControler, vamos acabar de implementar o GET e POST da aplicação.

 - A rota GET acionará um IActionResult Read que usará o cardrepository que criamos. Ele passará email por parametro para retornar os cartões pertencentes ao email informado. Será feito uma verificação se existe algum cartão vinculado ao email. Encontrando um ou mais cartões vinculados ao email, retornará um json a lista de cartões encontrado.

 - A rota POST acionará um IActionResult Create tambem utilizando o cardrepository e o model. Será chamado o método Create do cardrepository que irá gerar o novo cartão. Será realizada algumas validações para garantir que só gere o cartão se no json enviado exista um atributo email preenchido. Ele retornará os dados inserido no banco de dados.

 ![GET / POST](/img/getpost.png)


# Considerações Finais

 - Os endpoints foram testados utilizando o aplicativo Postman.
 - Neste projeto não foi criado a validação do número do cartão de crédito utilizando o algoritmo de Luhn.
 - Este projeto foi realizado para fins de estudo sobre o uso de .Net Core e Entity Framework e não gera números de cartões de crédito reais. São números totalmente aleatórios e a possibilidade de gerar um número de cartão de crédito real é quase inexistente.

 







