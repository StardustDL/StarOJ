#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.12-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/StarOJ/Shared/StarOJ.Shared.csproj", "src/StarOJ/Shared/"]
COPY ["src/StarOJ/Client/StarOJ.Client.csproj", "src/StarOJ/Client/"]
COPY ["src/StarOJ/Server/StarOJ.Server.csproj", "src/StarOJ/Server/"]
RUN dotnet restore "src/StarOJ/Server/StarOJ.Server.csproj" -s https://sparkshine.pkgs.visualstudio.com/StardustDL/_packaging/feed/nuget/v3/index.json -s https://api.nuget.org/v3/index.json
COPY . .
WORKDIR "/src/src/StarOJ/Server"
RUN dotnet build "StarOJ.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StarOJ.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StarOJ.Server.dll"]