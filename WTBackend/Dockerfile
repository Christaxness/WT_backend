<<<<<<< HEAD
# Build-Stage mit .NET 9.0 SDK
=======
# Diese Stufe wird verwendet, wenn sie von VS im Schnellmodus ausgeführt wird (Standardeinstellung für Debugkonfiguration).
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 10000

# Diese Stufe wird zum Erstellen des Dienstprojekts verwendet.
>>>>>>> 7f021581b18384423d589e090d6c148674335751
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
<<<<<<< HEAD
COPY ["WTBackend.csproj", "./"]
RUN dotnet restore "WTBackend.csproj"
COPY . .
RUN dotnet build "WTBackend.csproj" -c Release -o /app/build
=======
COPY ["WTBackend/WTBackend.csproj", "WTBackend/"]
RUN dotnet restore "./WTBackend/WTBackend.csproj"
COPY . . 
WORKDIR "/src/WTBackend"
RUN dotnet build "./WTBackend.csproj" -c $BUILD_CONFIGURATION -o /app/build
>>>>>>> 7f021581b18384423d589e090d6c148674335751

# Publish-Stage
FROM build AS publish
RUN dotnet publish "WTBackend.csproj" -c Release -o /app/publish

# Runtime-Stage mit .NET 9.0 Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
<<<<<<< HEAD
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "WTBackend.dll"]
=======
ENTRYPOINT ["dotnet", "WTBackend.dll"]
>>>>>>> 7f021581b18384423d589e090d6c148674335751
