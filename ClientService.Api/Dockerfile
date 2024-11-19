# Use .NET 8 SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy and restore project files
COPY ["ClientService.Api.csproj", "./"]
RUN dotnet restore "ClientService.Api.csproj"

# Copy the remaining files and build
COPY . .
RUN dotnet publish "ClientService.Api.csproj" -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ClientService.Api.dll"]