# Criando o ambiente de desenvolvimento

 - Primeiro passo, caso não tenha a SDK do .NET Core instalada, é baixar no site da Microsoft pelo link https://dotnet.microsoft.com/download/dotnet/.

 - Após instalado, vamos criar o ambiente de desenvolvimento. Pode-se usar o Visual Studio ou Visual Studio Code como IDE, no meu caso prefiro o Visual Studio Code por já usá-lo em outras linguagens de programação. 
    * Observação: Se optar por usar Visual Studio Code certifique-se de ter instalado a extensão para linguagem C#.

 - Crie a pasta onde ficará o projeto, utilize o PowerShell (caso utilize Windows) e vá até a pasta do projeto criada, execute o comando “code . “ para abrir o VS Code já com sua pasta de projeto aberta.

 - Abra o terminal do VS Code e execute o comando “dotnet new web –o nomedoprojeto” no meu caso o projeto chama backendcard. Feito isso será criado o projeto .NET e seus arquivos essenciais.

 - Ainda no terminal vamos executar comandos para adicionar pacotes que serão necessários no projeto. O primeiro é o Microsoft Entity Framework, execute o comando “dotnet add package Microsoft.EntityFrameworkCore” e o segundo é o InMemory, execute o comando “dotnet add package Microsoft.EntityFrameworkCore.InMemory”. O Microsoft Entity Framework é um ORM, assim ele abstrai a camada de comunicação com o banco de dados tornando o aplicativo flexivel em termos de banco de dados e declaração explícita de querys. O InMemory é para usarmos um “banco de dados” na memória já que não temos ainda definido um banco de dados a ser utilizado.
 
Feito estes passos o ambiente de desenvolvimento foi criado.

 ![Ambiente criado](/img/ambientedev.png)


# Criando as classes principais

 - Seguindo a arquitetura MVC vamos criar o Model e o Controller. Crie 2 novas pastas no projeto, uma com nome de “Models” e outra “Controllers”. Usando o MVC vamos separar as classes por suas funcionalidades. Na pasta Models crie um arquivo que conterá a classe de dados da api. No meu caso dei o nome de “Card.cs”, dentro do arquivo defina o namespace e crie a classe dos dados referente aos cartões que serão gerados. Veja na imagem:

 ![Model](/img/model.png)  

    * Observação: Poderia ser feito sem o atributo Id, porém resolvi deixar um identificador único para cada registro.

 - Agora vamos criar o arquivo “CardController.cs” na pasta Controllers, nele estarão as regras de negócio da api.
Após definir o namespace foi definido algumas características. Primeiro a propriedade ApiController para trabalhar com http requests e a rota para esse controller. A classe herdamos de ControllerBase. Dentro da rota definida como “card” vamos criar 2 http requests, um get para receber os dados do cartão criado e um post para criar os dados do cartão.

 ![Controller](/img/cardcontroller.png)


# Criando um repositório e o DbContext
 - Por hora deixaremos as classes de model e controller e vamos criar uma pasta “Repository” onde usaremos para criar um DataContext que herda DbContext do Entity Framework, que será responsável por carregar nosso banco de dados através do DataContextOptions que será definido mais adiante no arquivo Startup.cs, e o DbSet que pegará nosso objeto Card e persistir no banco por encapsulamento do Entity Framework. Usaremos também um repositório de regras de negócios chamado CardRepository para melhorar a organização e manutenibilidade do código.
 
 ![DataContext](/img/DataContext.png)


# CardRepository

 - Após criar a pasta Repository, crie dentro dela o arquivo CardRepository.cs. Neste arquivo criaremos uma Interface que fará a comunicação com o controller. Criaremos 2 métodos para um CRUD, no nosso caso fará somente a criação e a consulta, um para criação do cartão e outro para a leitura dos cartões criados. Aqui também criaremos um contrutor DataContext para ligar a camada de dados com o controller. 

 ![Interface](/img/cardrepository1.png)

 - Em Create teremos um algoritmo para que sejam gerados os números aleatórios do novo cartão de crédito e recebido em "Number" do nosso objeto "card", aqui também será gerado um id único através de um Guid. O email virá de um json passado pelo post. Ao final dessa função será adicionado um objeto Cards com as informações e persistida no nosso banco de dados através do SaveChanges(). Com o Entity Framework não precisamos criar querys sql. Será retornado desta função o objeto criado.

 - Em Read receberemos o email por parâmetro que virá através da rota que definimos em CardController. Se o email estiver vinculado a algum ou alguns cartões criados, a função retornará uma lista de objetos Card com os cartões vinculados a este email.

 ![Create / Read](/img/cardrepository2.png)


# Configurando arquivo Startup.cs

 - Abra o arquivo Startup.cs para configurar os serviços e endpoints da api. 

 - Adicionaremos os serviços que faz a comunicação com o InMemory, nosso banco de dados virtual, e o serviço que fará a ligação entre o repositório com o controller.

 - Também neste arquivo adicionaremos as configurações de endpoint definindo que Controller que irá mapear os endpoints.

 ![Startup.cs](/img/startup.png)


# GET e POST

 - Voltando ao arquivo CardControler, vamos acabar de implementar o GET e POST da aplicação.

 - A rota GET acionará um IActionResult que nomeei como Read que usará o CardRepository que criamos. Ele passará email por parâmetro para retornar os cartões pertencentes ao email informado. Será feito uma verificação se existe algum cartão vinculado ao email. Encontrando um ou mais cartões vinculados ao email, retornará um json da lista de cartões encontrados.

 - A rota POST acionará um IActionResult que nomeei como Create também utilizando o CardRepository e um "model" de Card. Será chamado o método Create do CardRepository que irá gerar o novo cartão de crédito. Serão realizadas algumas validações para garantir que só gere o cartão se no json enviado exista um atributo "email" e que ele esteja preenchido. Retornará os dados do cartão que foi gerado.

 ![GET / POST](/img/getpost.png)



# Resultado

 - Para executar a API, vá em terminal e escreva o comando "dotnet watch run" e tecle enter.
 - Abaixo veja algumas imagens da API em funcionamento: 

   Realizando o POST

 ![Post email@email.com](/img/resultado_post1.png)

 ![Post email2@email.com](/img/resultado_post2.png)

   Realizando o GET

 ![Get email@email.com](/img/resultado_get1.png)

 ![Get email2@email.com](/img/resultado_get2.png)

# Considerações Finais

 - Os endpoints foram testados utilizando o aplicativo Postman.
 - Neste projeto não foi criado a validação do número do cartão de crédito utilizando o algoritmo de Luhn.
 - Este projeto foi realizado para fins de estudo sobre o uso de .Net Core e Entity Framework e não gera números de cartões de crédito reais. São números totalmente aleatórios e a possibilidade de gerar um número de cartão de crédito real é quase inexistente.

 







