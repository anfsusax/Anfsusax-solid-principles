# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia a solução e os projetos
COPY backend/BiblicalArchitecture.sln ./
COPY backend/BiblicalArchitecture.API/BiblicalArchitecture.API.csproj BiblicalArchitecture.API/
COPY backend/BiblicalArchitecture.Application/BiblicalArchitecture.Application.csproj BiblicalArchitecture.Application/
COPY backend/BiblicalArchitecture.Domain/BiblicalArchitecture.Domain.csproj BiblicalArchitecture.Domain/
COPY backend/BiblicalArchitecture.Infrastructure/BiblicalArchitecture.Infrastructure.csproj BiblicalArchitecture.Infrastructure/

# Restaura dependências
RUN dotnet restore

# Copia todo o código
COPY backend/ .

# Publica a API
RUN dotnet publish BiblicalArchitecture.API/BiblicalArchitecture.API.csproj -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Cria diretório persistente para o SQLite
RUN mkdir -p /app/data

COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "BiblicalArchitecture.API.dll"]
