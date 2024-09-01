FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/AtendoCloudSystem.Web.Host/AtendoCloudSystem.Web.Host.csproj", "src/AtendoCloudSystem.Web.Host/"]
COPY ["src/AtendoCloudSystem.Web.Core/AtendoCloudSystem.Web.Core.csproj", "src/AtendoCloudSystem.Web.Core/"]
COPY ["src/AtendoCloudSystem.Application/AtendoCloudSystem.Application.csproj", "src/AtendoCloudSystem.Application/"]
COPY ["src/AtendoCloudSystem.Core/AtendoCloudSystem.Core.csproj", "src/AtendoCloudSystem.Core/"]
COPY ["src/AtendoCloudSystem.EntityFrameworkCore/AtendoCloudSystem.EntityFrameworkCore.csproj", "src/AtendoCloudSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/AtendoCloudSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AtendoCloudSystem.Web.Host", "src/AtendoCloudSystem.Web.Host"]
COPY ["src/AtendoCloudSystem.Web.Core", "src/AtendoCloudSystem.Web.Core"]
COPY ["src/AtendoCloudSystem.Application", "src/AtendoCloudSystem.Application"]
COPY ["src/AtendoCloudSystem.Core", "src/AtendoCloudSystem.Core"]
COPY ["src/AtendoCloudSystem.EntityFrameworkCore", "src/AtendoCloudSystem.EntityFrameworkCore"]
WORKDIR "/src/src/AtendoCloudSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AtendoCloudSystem.Web.Host.dll"]
