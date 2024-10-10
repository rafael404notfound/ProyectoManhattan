# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Install selenium
RUN apt-get update && \
    apt-get install -y --no-install-recommends gnupg wget curl unzip && \
    wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    echo "deb http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google.list && \
    apt-get update -y && \
    apt-get install -y --no-install-recommends google-chrome-stable && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* /var/cache/apt/*

# Install chrome driver
RUN export CHROMEDRIVER_VERSION=$(curl -s "https://googlechromelabs.github.io/chrome-for-testing/LATEST_RELEASE_STABLE"); \
wget -q --continue -P /chromedriver "https://chromedriver.storage.googleapis.com/${CHROMEDRIVER_VERSION}/chromedriver_linux64.zip"; \
echo ""

USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


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

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProyectoManhattan.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoManhattan.Server.dll"]