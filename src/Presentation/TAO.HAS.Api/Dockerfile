#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Presentation/TAO.HAS.Api/TAO.HAS.Api.csproj", "src/Presentation/TAO.HAS.Api/"]
COPY ["src/Infrastructure/TAO.HAS.Persistence/TAO.HAS.Persistence.csproj", "src/Infrastructure/TAO.HAS.Persistence/"]
COPY ["src/Core/TAO.HAS.Application/TAO.HAS.Application.csproj", "src/Core/TAO.HAS.Application/"]
COPY ["src/Core/TAO.HAS.Domain/TAO.HAS.Domain.csproj", "src/Core/TAO.HAS.Domain/"]
RUN dotnet restore "src/Presentation/TAO.HAS.Api/TAO.HAS.Api.csproj"
COPY . .
WORKDIR "/src/src/Presentation/TAO.HAS.Api"
RUN dotnet build "TAO.HAS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TAO.HAS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TAO.HAS.Api.dll"]