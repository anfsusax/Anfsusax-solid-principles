# Biblical Architecture

Aplicação web para estudo e visualização de arquitetura bíblica, implementando princípios SOLID e Clean Architecture.

## 🏗️ Estrutura do Projeto

O projeto está organizado em duas pastas principais:

### Backend (`.NET`)
- `BiblicalArchitecture.API`: Camada de API REST
- `BiblicalArchitecture.Application`: Lógica de negócios e casos de uso
- `BiblicalArchitecture.Domain`: Entidades e interfaces de domínio
- `BiblicalArchitecture.Infrastructure`: Implementações de infraestrutura (banco de dados, serviços externos)

### Frontend (`Angular`)
- `arquitetura-biblica-ui`: Aplicação Angular com Material UI

## 🚀 Como executar

### Pré-requisitos

- [.NET 7.0+](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (versão LTS recomendada)
- [Angular CLI](https://angular.io/cli)
- [Docker](https://www.docker.com/) (opcional, para execução em containers)

### Backend

```bash
# Navegue até a pasta do backend
cd backend

# Restaure os pacotes e execute a aplicação
dotnet restore
dotnet run --project BiblicalArchitecture.API
```

A API estará disponível em: `https://localhost:5001` ou `http://localhost:5000`

### Frontend

```bash
# Navegue até a pasta do frontend
cd frontend/arquitetura-biblica-ui

# Instale as dependências
npm install

# Inicie o servidor de desenvolvimento
ng serve
```

O frontend estará disponível em: `http://localhost:4200`

## 🐳 Executando com Docker

### Backend

```bash
# Na raiz do projeto backend
docker build -t biblical-architecture-api .
docker run -p 5000:80 -p 5001:443 biblical-architecture-api
```

## 🛠️ Tecnologias Utilizadas

### Backend
- .NET 7.0+
- Entity Framework Core
- SQL Server (ou outro banco de dados suportado pelo EF Core)
- Swagger/OpenAPI para documentação

### Frontend
- Angular 20+
- Angular Material
- RxJS
- NgxMarkdown para renderização de conteúdo

## 📝 Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para detalhes.

## 🤝 Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e enviar pull requests.
