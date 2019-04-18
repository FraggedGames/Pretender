FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pretender.Server/Pretender.Server.csproj", "Pretender.Server/"]
RUN dotnet restore "Pretender.Server/Pretender.Server.csproj"
COPY . .
WORKDIR "/src/Pretender.Server"
RUN dotnet build "Pretender.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pretender.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pretender.Server.dll"]