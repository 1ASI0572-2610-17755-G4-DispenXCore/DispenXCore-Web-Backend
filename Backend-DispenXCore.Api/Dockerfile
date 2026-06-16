# Etapa 1: Compilación usando el SDK oficial de Microsoft para .NET 9
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos el archivo de proyecto y restauramos dependencias
COPY Backend-DispenXCore.Api.csproj ./
RUN dotnet restore "Backend-DispenXCore.Api.csproj"

# Copiamos todo tu código y compilamos
COPY . .
RUN dotnet publish "Backend-DispenXCore.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Imagen súper ligera solo para ejecutar tu API
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

# Traemos lo compilado de la Etapa 1
COPY --from=build /app/publish .

# Comando para encender tu backend
ENTRYPOINT ["dotnet", "Backend-DispenXCore.Api.dll"]
