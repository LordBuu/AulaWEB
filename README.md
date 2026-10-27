ExoLanchonetePedido — EF Core + MVC Premium

Projeto desenvolvido com ASP.NET Core, Entity Framework Core, SQLite, Repository e Service, baseado na Aula 09/10.

Como executar o projeto

No terminal, dentro da pasta do projeto, execute os comandos:

bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run


Após iniciar a aplicação, acesse o endereço indicado no terminal. Por padrão, pode ser http://localhost:5000, dependendo da configuração do projeto.

Páginas
/ — Dashboard
/produtos — Cardápio
/pedidos — Lista de pedidos
/pedidos/novo — Criar novo pedido
/pedidos/{numero} — Detalhes do pedido
API
/api/produtos — Endpoints de produtos
/api/pedidos — Endpoints de pedidos
Tecnologias utilizadas
ASP.NET Core
Entity Framework Core
SQLite
Repository Pattern
Service Layer
MVC (Model-View-Controller)
Observação

Este projeto faz parte dos estudos de desenvolvimento web com .NET, utilizando banco de dados SQLite e organização em camadas para separar as responsabilidades da aplicação.