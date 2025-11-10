# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia a solução
COPY BiblicalArchitecture.sln ./

# Copia os projetos
COPY BiblicalArchitecture.API/BiblicalArchitecture.API.csproj BiblicalArchitecture.API/
COPY BiblicalArchitecture.Application/BiblicalArchitecture.Application.csproj BiblicalArchitecture.Application/
COPY BiblicalArchitecture.Domain/BiblicalArchitecture.Domain.csproj BiblicalArchitecture.Domain/
COPY BiblicalArchitecture.Infrastructure/BiblicalArchitecture.Infrastructure.csproj BiblicalArchitecture.Infrastructure/

# Restaura dependências
RUN dotnet restore

# Copia o restante dos arquivos
COPY . .

# Publica a aplicação
RUN dotnet publish BiblicalArchitecture.API/BiblicalArchitecture.API.csproj -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Cria a pasta para o banco SQLite
RUN mkdir -p /app/data

COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "BiblicalArchitecture.API.dll"]
