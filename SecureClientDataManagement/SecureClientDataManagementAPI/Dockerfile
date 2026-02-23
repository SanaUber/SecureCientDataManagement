 FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM --platform=linux/amd64 mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SecureCientDataManagementAPI.csproj", "."]
RUN dotnet restore "./SecureCientDataManagementAPI.csproj"
COPY . .
RUN dotnet build "./SecureCientDataManagementAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./SecureCientDataManagementAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecureCientDataManagementAPI.dll"]