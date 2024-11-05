# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER root
WORKDIR /app
RUN chown -R root /app

EXPOSE 5000
EXPOSE 5001

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
#RUN dotnet dev-certs https
WORKDIR /src
COPY ["ProyectoManhattan.Server/ProyectoManhattan.Server.csproj", "ProyectoManhattan.Server/"]
COPY ["ProyectoManattan.Infrastructure/ProyectoManhattan.Infrastructure.csproj", "ProyectoManattan.Infrastructure/"]
COPY ["ProyectoManhattan.Application/ProyectoManhattan.Application.csproj", "ProyectoManhattan.Application/"]
COPY ["ProyectoManhattan.Domain/ProyectoManhattan.Domain.csproj", "ProyectoManhattan.Domain/"]
COPY ["ProyectoManhattan.Client/ProyectoManhattan.Client.csproj", "ProyectoManhattan.Client/"]
COPY ["ProyectoManhattan.BlazorComponents/ProyectoManhattan.BlazorComponents.csproj", "ProyectoManhattan.BlazorComponents/"]
RUN dotnet restore "./ProyectoManhattan.Server/ProyectoManhattan.Server.csproj"
COPY . .
WORKDIR "/src/ProyectoManhattan.Server"
RUN dotnet build "./ProyectoManhattan.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProyectoManhattan.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM mcr.microsoft.com/playwright/dotnet:v1.47.0-noble AS final
WORKDIR /app
#COPY --from=publish /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
COPY --from=publish /app/publish /app
ENTRYPOINT ["dotnet", "ProyectoManhattan.Server.dll"]