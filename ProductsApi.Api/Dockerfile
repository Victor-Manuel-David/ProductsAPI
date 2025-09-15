#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ProductsApi.Api/ProductsApi.Api.csproj", "src/ProductsApi.Api/"]
COPY ["src/ProductsApi.Application/ProductsApi.Application.csproj", "src/ProductsApi.Application/"]
COPY ["src/ProductsApi.Domain/ProductsApi.Domain.csproj", "src/ProductsApi.Domain/"]
COPY ["src/Shared.Contracts/Shared.Contracts.csproj", "src/Shared.Contracts/"]
COPY ["src/ProductsApi.Infrastructure/ProductsApi.Infrastructure.csproj", "src/ProductsApi.Infrastructure/"]
RUN dotnet restore "./src/ProductsApi.Api/ProductsApi.Api.csproj"
COPY . .
WORKDIR "/src/src/ProductsApi.Api"
RUN dotnet build "./ProductsApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductsApi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsApi.Api.dll"]