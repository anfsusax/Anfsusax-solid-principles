# BiblicalArchitecture.API

API em ASP.NET Core que alimenta a plataforma **Arquitetura Bíblica**, oferecendo módulos de estudo e conteúdos sobre os princípios SOLID com referências bíblicas. O projeto segue uma arquitetura multi-camadas (API → Application → Domain → Infrastructure) e utiliza **Entity Framework Core 9** com **SQLite** como banco de dados padrão.

## Visão Geral

- **Framework**: .NET 9 (ASP.NET Core Web API)
- **Persistência**: Entity Framework Core 9 + SQLite
- **Documentação**: Swagger UI habilitado em `/swagger`
- **Hospedagem**: Railway (Docker)
- **Camadas**:
  - `BiblicalArchitecture.Domain`: entidades, interfaces e serviços de domínio
  - `BiblicalArchitecture.Application`: orquestração de casos de uso
  - `BiblicalArchitecture.Infrastructure`: repositórios, contexto EF e seed
  - `BiblicalArchitecture.API`: controllers e configuração de DI/CORS

## Pré-requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Entity Framework Core CLI](https://learn.microsoft.com/ef/core/cli/dotnet) (opcional para migrations)
- Docker (opcional para execução containerizada)

## Primeiros Passos

### 1. Clonar o repositório
```bash
git clone https://github.com/anfsusax/Anfsusax-solid-principles.git
cd Anfsusax-solid-principles
```

### 2. Restaurar dependências
```bash
dotnet restore BiblicalArchitecture.sln
```

### 3. Executar a API
```bash
dotnet run --project backend/BiblicalArchitecture.API
# Swagger: http://localhost:5080/swagger (porta exata conforme output)
```
A base SQLite (`BiblicalArchitecture.db`) é criada e populada automaticamente na primeira execução.

## Variáveis de Ambiente

| Variável                               | Descrição                                                                                 | Padrão                                      |
| -------------------------------------- | ----------------------------------------------------------------------------------------- | ------------------------------------------- |
| `ConnectionStrings__DefaultConnection` | Connection string para o banco. Utilize SQLite (arquivo) ou qualquer provedor suportado. | `Data Source=/app/data/biblical.db` (Docker)|
| `ASPNETCORE_ENVIRONMENT`               | Define o ambiente (`Development`, `Production`, etc.).                                     | `Production` (Railway)                      |

## Principais Endpoints

| Método | Rota                           | Descrição                                   |
| ------ | ------------------------------ | ------------------------------------------- |
| GET    | `/api/solid`                   | Lista todos os princípios SOLID             |
| GET    | `/api/solid/{id}`              | Obtém um princípio por ID                   |
| GET    | `/api/solid/{sigla}`           | Obtém um princípio pela sigla (S, O, L, I, D) |
| GET    | `/api/modulos`                 | Lista módulos de estudo                     |
| GET    | `/api/modulos/{id}`            | Obtém um módulo com aulas e exemplos        |

Swagger UI disponível em `/swagger/index.html`.

## Migrations e Seed

O contexto `ApplicationDbContext` utiliza `EnsureCreatedAsync` no startup. Caso deseje manter o fluxo de migrations:

```bash
cd backend/BiblicalArchitecture.API
# Novo migration
dotnet ef migrations add NomeDaMigration --project ../BiblicalArchitecture.Infrastructure --startup-project .
# Aplicar migrations
dotnet ef database update --project ../BiblicalArchitecture.Infrastructure --startup-project .
```

O seed inicial está em `BiblicalArchitecture.Infrastructure/Data/ModuloSeedData.cs`.

## Docker

### Build
```bash
docker build -f backend/Dockerfile -t biblical-api .
```

### Run
```bash
docker run -d -p 8080:8080 --name biblical-api biblical-api
# Swagger: http://localhost:8080/swagger/index.html
```

O Dockerfile cria a pasta `/app/data` dentro do container para armazenar o banco SQLite (`/app/data/biblical.db`). 

## Deploy na Railway

1. Configure o serviço para usar o arquivo `backend/Dockerfile`.
2. Defina as variáveis de ambiente (se necessário).
3. Gere um domínio público a partir do painel da Railway.
4. Faça o redeploy; o container sobe escutando em `http://0.0.0.0:8080`.

## Contribuindo

1. Crie uma branch descritiva: `git checkout -b feature/nova-feature`
2. Faça commit seguindo boas práticas: `git commit -m "Add nova feature"`
3. Abra um Pull Request com detalhes das mudanças.

## Licença

Projeto mantido para fins educacionais. Consulte o autor antes de utilizar em produção.
