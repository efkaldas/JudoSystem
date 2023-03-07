#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get install -y libgdiplus
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["JudoSystem/JudoSystem.csproj", "JudoSystem/"]
COPY ["ActionFilters/ActionFilters.csproj", "ActionFilters/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Enums/Enums.csproj", "Enums/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore "JudoSystem/JudoSystem.csproj"
COPY . .
WORKDIR "/src/JudoSystem"
RUN dotnet build "JudoSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JudoSystem.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JudoSystem.dll"]