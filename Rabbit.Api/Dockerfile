# See https://aka.ms/containercompat for container compatibility details.

# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Rabbit.Api/Rabbit.Api.csproj", "Rabbit.Api/"]
RUN dotnet restore "./Rabbit.Api/Rabbit.Api.csproj"
COPY . .
WORKDIR "/src/Rabbit.Api"
RUN dotnet build "./Rabbit.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Rabbit.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rabbit.Api.dll"]
