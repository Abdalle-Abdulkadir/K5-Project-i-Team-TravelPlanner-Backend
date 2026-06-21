# Build stage - compile and publish the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["TravelPlanner.Api.csproj", "./"]
RUN dotnet restore "TravelPlanner.Api.csproj"

COPY . .
RUN dotnet publish "TravelPlanner.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage - lightweight production image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

EXPOSE 8080

# Run container as non-root user (rootless)
USER app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "TravelPlanner.Api.dll"]


