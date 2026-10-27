# ExoLanchonetePedido — EF Core + MVC Premium

Projeto baseado na Aula 09/10: ASP.NET Core, Entity Framework Core, SQLite, Repository e Service.

## Rodar
```bash
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

Abra `http://localhost:5000`.

## Páginas
- `/` Dashboard
- `/produtos` Cardápio
- `/pedidos` Pedidos
- `/pedidos/novo` Novo pedido
- `/pedidos/{numero}` Detalhes

## API
- `/api/produtos`
- `/api/pedidos`
