# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY backend/BiblicalArchitecture.API/BiblicalArchitecture.API.csproj BiblicalArchitecture.API/
COPY backend/ backend/

RUN dotnet restore BiblicalArchitecture.API/BiblicalArchitecture.API.csproj
RUN dotnet publish BiblicalArchitecture.API/BiblicalArchitecture.API.csproj -c Release -o /app/publish

# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "BiblicalArchitecture.API.dll"]
