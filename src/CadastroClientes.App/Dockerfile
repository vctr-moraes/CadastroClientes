FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CadastroClientes.App/CadastroClientes.App.csproj", "CadastroClientes.App/"]
COPY ["CadastroClientes.Business/CadastroClientes.Business.csproj", "CadastroClientes.Business/"]
COPY ["CadastroClientes.Data/CadastroClientes.Data.csproj", "CadastroClientes.Data/"]
COPY ["CadastroClientes.Infrastructure/CadastroClientes.Infrastructure.csproj", "CadastroClientes.Infrastructure/"]
RUN dotnet restore "CadastroClientes.App/CadastroClientes.App.csproj"
COPY . .
WORKDIR "CadastroClientes.App"
RUN dotnet build "CadastroClientes.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CadastroClientes.App.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadastroClientes.App"]