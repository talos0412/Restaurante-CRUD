# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiamos el csproj y restauramos las dependencias
COPY ["PROYECTO_MONGO_DOTNET.csproj", "./"]
RUN dotnet restore "PROYECTO_MONGO_DOTNET.csproj"

# Copiamos todo el código y lo publicamos
COPY . .
RUN dotnet publish "PROYECTO_MONGO_DOTNET.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa de ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

# Configuramos la aplicación para escuchar en el puerto 8080 que es el estándar de .NET 8
ENV ASPNETCORE_HTTP_PORTS=8080

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PROYECTO_MONGO_DOTNET.dll"]
