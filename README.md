# Nivello
## Teste para Tech Lead na empresa Nivello

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)


## Features

- Criar um cadastro de produtos de um leilão com os campos Nome, Valor e Foto.
- Criar um cadastro de pessoa.
- Possibilitar a pessoa fazer um lance em um produto.

## Tech

Tecnologias e conceitos usados :

- [.NetCore](https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/install) - Backend!
- [ReactJs](https://reactjs.org/) - Frontend
- [EF Core](https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli) - Conexao com banco de dados.
- [Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) - Banco de dados
- [Material Ui](https://mui.com/pt/) - Componentes de tela.
- [Axios](https://github.com/axios/axios) - Requisicoes Http
- [Swagger](https://swagger.io/) - Documentar Api

## Instalacao

### Clonar Repositorio
Basta clonar o repositório normalmente pelo GitHub, ou como arquivo .zip.

### Rodar Migration

-Insira dos dados do seu banco sql na connection string dentro do arquivo **appsettings.json** no projeto **Nivello.Api**.

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/appsetings.png?raw=true)

-Agora selecione o projeto **Nivello.Infrastructure**.
-Execute os seguintes comandos:
```sh
Add-Migration InitialCreate -o Data/Migrations
update-database
```
Apos isso seu banco deve ficar com a seguinte estrutura:

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/dataBaseSchema.png?raw=true)
> Note: Deve se verificar se a tabela SystemAdmin foi populada corretamente, com usuario administrador.

### Instalar dependencias do portal
-Acessar pasta **\nivello\web-site**.
-Rodar o comando
```sh
npm install --force
```
-Aguardar a instalacao dos pacotes

> Note: Apos sua base de dados configurada e as dependencias do portal baixadas voce esta apto pra executar a aplicacao.

## Executar aplicacao
### Executar Api
Basta definir o projeto **Nivello.Api** como principal, e executar usando o IIS. Apos executar aparecera a tela do Swagger contendo a documentacao da api, como na imagem:

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/swaggerIndex.png?raw=true)

### Executar Web Site
-Acessar pasta **\nivello\web-site**.
-Definir no arquivo **nivello\web-site\src\services\axios\index.js** o endereco base da api

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/axios.png?raw=true)

-Rodar o comando
```sh
npm start
```

## Usar a aplicacao
### Como administrador
- Para acesso aos sistema devem ser usados as credenciais, geradas pelas migrations:
-- Voce pode criar um novo usuario administrador, basta acessa o projeto **Nivello.Infrastructure**. nas classe **Context**, como na imagem aseguir: 
As credenciais definadas foram: 

    | Email | Senha |
    | ------ | ------ |
    | admin@nivello.com | **123456** |

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/CreateAdmin.png?raw=true)

#### Fazer login no site
Quando logar como administrador deve ser marcar o parametro na tela de login: 
![strong text](https://github.com/osnjunior91/nivello/blob/main/images/LoginAdm.png?raw=true)


Apos efetuado o login como administrador sera exibida a seguinte tela: 

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/indexadmin.png?raw=true)

##### Nesta tela voce pode: 
* Visualizar os produtos ativos na base.
* Inserir novos produtos
* Finalizar um produto ativo

Voce pode tambem acessar a tela de visualizacao dos clientes: 

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/vizualizarcustomer.png?raw=true)

##### Nesta tela voce pode: 
* Visualizar os lances por cliente.
* Filtrar por nome do cliente
* Visualizar o produto em detalhe


### Como cliente

Para acessar o sistema como cliente deve primeiro, cadastrar um cliente, na tela de login existe o linke **Criar cadastro no sistema** que ira te redirecionar para a pagina de cadastro: 

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/cadastro.png?raw=true)

Apos isso basta fazer o login normalmente como customer (sem selecioonar opcao admin na tela de login) e aparecera uma tela parecida com a de admim porem com opcoes diferentes.

![strong text](https://github.com/osnjunior91/nivello/blob/main/images/homecustomer.png?raw=true)

##### Nesta tela voce pode: 
* Visualizar os produtos ativos.
* Fazer lance em algum produto.
* Acessar seu historico de lances.


Bom basicamente essas sao as funcionalidades basicas do sistema.

Qualquer duvida me econtro a disposicao.

## License

MIT

**Free Software!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>
