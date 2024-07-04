# BlessedBarbershop
A BlessedBarbershop é uma barbearia que oferece serviços de barbearia e vende produtos relacionados. Este projeto é uma Web API em C# utilizando ASP.NET Core para gerenciar clientes, produtos/serviços, vendas e pontos.

## Tecnologias e ferramentas utilizadas
- Visual Studio 2022
- ASP.NET Core 8
- EF Core
- Swagger
- Repository Pattern
- Data Transfer Object (DTO)

## Instalação
Para configurar o projeto em sua máquina local:

### 1 - Clone o repositório:
```bash
  git clone https://github.com/joselitomachado/BlessedBarbershop.git
```

### 2 - Atualize a string de conexão no appsettings.json:
```bash
  "ConnectionStrings": {
      "BlessedBarbershopCs": "Server=(localdb)\\mssqllocaldb; Database=DBBarbershop; Integrated Security=True; TrustServerCertificate=True"
    }
```

### 3 - Execute as migrações para criar o banco de dados:
```bash
  Add-Migration InitialCreate
  Update-Database
```

## Endpoints
### Produtos e Serviços
- Cadastrar Produto/Serviço
- Visualizar Todos os Produtos/Serviços
- Visualizar Produto/Serviço por ID
- Visualizar Produto/Serviço por Nome
- Editar Produto/Serviço
- Excluir Produto/Serviço

### Clientes
- Cadastrar Cliente
- Visualizar Todos os Clientes
- Visualizar Cliente por ID
- Visualizar Cliente por Nome
- Editar Cliente
- Excluir Cliente

### Vendas
- Cadastrar Venda
- Visualizar Venda por ID
- Visualizar Vendas por Cliente
- Visualizar Todas as Vendas
- Visualizar Vendas por Data
- Excluir Venda

## Conclusão
A API BlessedBarbershop oferece uma solução completa para gerenciar clientes, produtos/serviços, vendas e pontos de fidelidade. Esta documentação fornece uma visão geral dos endpoints e configurações necessárias para começar a usar a API. Para mais detalhes, consulte o código-fonte e a documentação dos endpoints diretamente no Swagger.
