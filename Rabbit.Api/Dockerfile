FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Base image for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["Rabbit.Api.csproj", "./"]
RUN dotnet restore "Rabbit.Api.csproj"

# Copy the rest of the app and build
COPY . .
WORKDIR "/src"
RUN dotnet build "Rabbit.Api.csproj" -c Release -o /app/build

# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .

ENTRYPOINT ["dotnet", "Rabbit.Api.dll"]
