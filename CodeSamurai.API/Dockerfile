FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

USER root
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
USER root
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["CodeSamurai.API/CodeSamurai.API.csproj", "CodeSamurai.API/"]
RUN dotnet restore "./CodeSamurai.API/./CodeSamurai.API.csproj"
COPY . .
WORKDIR "/src/CodeSamurai.API"
RUN dotnet build "./CodeSamurai.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN apt-get update && apt-get install -y libgssapi-krb5-2

FROM build AS publish
USER root
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CodeSamurai.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
RUN apt-get update && apt-get install -y libgssapi-krb5-2
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CodeSamurai.API.dll"]