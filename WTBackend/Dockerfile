# Build-Stage mit .NET 9.0 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["WTBackend.csproj", "./"]
RUN dotnet restore "WTBackend.csproj"
COPY . .
RUN dotnet build "WTBackend.csproj" -c Release -o /app/build

# Publish-Stage
FROM build AS publish
RUN dotnet publish "WTBackend.csproj" -c Release -o /app/publish

# Runtime-Stage mit .NET 9.0 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "WTBackend.dll"]