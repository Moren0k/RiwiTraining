FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Watchwi.Api/Watchwi.Api.csproj", "src/Watchwi.Api/"]
COPY ["src/Watchwi.Application/Watchwi.Application.csproj", "src/Watchwi.Application/"]
COPY ["src/Watchwi.Domain/Watchwi.Domain.csproj", "src/Watchwi.Domain/"]
COPY ["src/Watchwi.Infrastructure/Watchwi.Infrastructure.csproj", "src/Watchwi.Infrastructure/"]
RUN dotnet restore "src/Watchwi.Api/Watchwi.Api.csproj"
COPY . .
WORKDIR "/src/src/Watchwi.Api"
RUN dotnet build "./Watchwi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Watchwi.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Watchwi.Api.dll"]
