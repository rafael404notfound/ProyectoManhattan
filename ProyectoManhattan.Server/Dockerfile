# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER root
WORKDIR /app
RUN chown -R root /app

EXPOSE 8080
EXPOSE 8081

RUN apt-get update -yq && apt-get upgrade -yq && apt-get install -yq curl git nano
RUN curl -sL https://deb.nodesource.com/setup_16.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install -g npm@latest

RUN apt-get install -y wget xvfb unzip

# Set up the Chrome PPA
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list

# Update the package list and install chrome
RUN apt-get update -y
RUN apt-get install -y google-chrome-stable
RUN apt-get install -y firefox

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
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
RUN npx playwright install-deps
RUN npx playwright install

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProyectoManhattan.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoManhattan.Server.dll"]