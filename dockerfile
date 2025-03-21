# Usa la imagen base de .NET 5.0 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5000

# Usa la imagen de SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copia los archivos de la solución y restaura las dependencias

COPY ["NutritionalAdvice.sln", "."]
COPY ["NutritionalAdvice.Domain/NutritionalAdvice.Domain.csproj", "NutritionalAdvice.Domain/"]
COPY ["NutritionalAdvice.Application/NutritionalAdvice.Application.csproj", "NutritionalAdvice.Application/"]
COPY ["NutritionalAdvice.Infrastructure/NutritionalAdvice.Infrastructure.csproj", "NutritionalAdvice.Infrastructure/"]
COPY ["NutritionalAdvice.WebApi/NutritionalAdvice.WebApi.csproj", "NutritionalAdvice.WebApi/"]

# Restaura los paquetes NuGet
RUN dotnet restore "./NutritionalAdvice.WebApi/NutritionalAdvice.WebApi.csproj"

# Copia todo el código fuente
COPY . .

# Compila la solución
WORKDIR "/src/NutritionalAdvice.WebApi"
RUN dotnet build "NutritionalAdvice.WebApi.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "./NutritionalAdvice.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Crea la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NutritionalAdvice.WebApi.dll"]