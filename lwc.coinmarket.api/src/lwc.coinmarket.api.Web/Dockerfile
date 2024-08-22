# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Directory.Build.props", "src/"]
COPY ["Directory.Packages.props", "src/"]
COPY ["src/lwc.coinmarket.api.Web/lwc.coinmarket.api.Web.csproj", "src/lwc.coinmarket.api.Web/"]
COPY ["src/lwc.coinmarket.api.Infrastructure/lwc.coinmarket.api.Infrastructure.csproj", "src/lwc.coinmarket.api.Infrastructure/"]
COPY ["src/lwc.coinmarket.api.Core/lwc.coinmarket.api.Core.csproj", "src/lwc.coinmarket.api.Core/"]
COPY ["src/lwc.coinmarket.api.UseCases/lwc.coinmarket.api.UseCases.csproj", "src/lwc.coinmarket.api.UseCases/"]
RUN dotnet restore "./src/lwc.coinmarket.api.Web/lwc.coinmarket.api.Web.csproj"
COPY . .
WORKDIR "/src/src/lwc.coinmarket.api.Web"
RUN dotnet build "./lwc.coinmarket.api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./lwc.coinmarket.api.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lwc.coinmarket.api.Web.dll"]