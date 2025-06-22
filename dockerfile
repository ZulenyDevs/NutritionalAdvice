# Usa la imagen base de .NET 8.0 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5000

# Usa la imagen de SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de la solución y restaura las dependencias

COPY ["NutritionalAdvice.sln", "."]
COPY ["NutritionalAdvice.Domain/NutritionalAdvice.Domain.csproj", "NutritionalAdvice.Domain/"]
COPY ["NutritionalAdvice.Application/NutritionalAdvice.Application.csproj", "NutritionalAdvice.Application/"]
COPY ["NutritionalAdvice.Integration/NutritionalAdvice.Integration.csproj", "NutritionalAdvice.Integration/"]
COPY ["NutritionalAdvice.Infrastructure/NutritionalAdvice.Infrastructure.csproj", "NutritionalAdvice.Infrastructure/"]
COPY ["NutritionalAdvice.WebApi/NutritionalAdvice.WebApi.csproj", "NutritionalAdvice.WebApi/"]
COPY ["NutritionalAdvice.WorkerService/NutritionalAdvice.WorkerService.csproj", "NutritionalAdvice.WorkerService/"]

# Restaura los paquetes NuGet
RUN dotnet restore "./NutritionalAdvice.WebApi/NutritionalAdvice.WebApi.csproj"
RUN dotnet restore "./NutritionalAdvice.WorkerService/NutritionalAdvice.WorkerService.csproj"

# Copia todo el código fuente
COPY . .

# Compila la solución
WORKDIR "/src/NutritionalAdvice.WebApi"
RUN dotnet build "NutritionalAdvice.WebApi.csproj" -c Release -o /app/build/webapi

WORKDIR "/src/NutritionalAdvice.WorkerService"
RUN dotnet build "NutritionalAdvice.WorkerService.csproj" -c Release -o /app/build/workerservice


# Publica la aplicación
FROM build AS publish
WORKDIR "/src/NutritionalAdvice.WebApi"
RUN dotnet publish "./NutritionalAdvice.WebApi.csproj" -c Release -o /app/publish/webapi /p:UseAppHost=false

FROM build AS publish-workerservice
WORKDIR "/src/NutritionalAdvice.WorkerService"
RUN dotnet publish "./NutritionalAdvice.WorkerService.csproj" -c Release -o /app/publish/workerservice /p:UseAppHost=false

# Crea la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/webapi .
COPY --from=publish-workerservice /app/publish/workerservice .

# Crea el script de inicio
RUN echo '#!/bin/bash \n\
dotnet /app/NutritionalAdvice.WebApi.dll & \n\
dotnet /app/NutritionalAdvice.WorkerService.dll \n\
wait' > /app/entrypoint.sh && \
chmod +x /app/entrypoint.sh

ENTRYPOINT ["/bin/bash", "/app/entrypoint.sh"]
