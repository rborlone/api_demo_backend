#Primera etapa generamos la compilacion y limpiamos el proyecto
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ApiDemo.Infra/ApiDemo.Infra.csproj", "./ApiDemo.Infra/"]
COPY ["ApiDemo.Domain/ApiDemo.Domain.csproj", "./ApiDemo.Domain/"]
COPY ["ApiDemo.WebApi/ApiDemo.WebApi.csproj", "./ApiDemo.WebApi/"]

RUN dotnet restore "ApiDemo.Infra/ApiDemo.Infra.csproj"
RUN dotnet restore "ApiDemo.Domain/ApiDemo.Domain.csproj"
RUN dotnet restore "ApiDemo.WebApi/ApiDemo.WebApi.csproj"

COPY . .

WORKDIR "/src/."
RUN dotnet build "ApiDemo.Infra/ApiDemo.Infra.csproj" -c Release -o /app/build

WORKDIR "/src/."
RUN dotnet build "ApiDemo.Domain/ApiDemo.Domain.csproj" -c Release -o /app/build

WORKDIR "/src/."
RUN dotnet build "ApiDemo.WebApi/ApiDemo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiDemo.WebApi/ApiDemo.WebApi.csproj" -c Release -o /app/publish

#Segunda etapa generamos el contenedor y le damos un punto de entrada.
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiDemo.WebApi.dll"]
