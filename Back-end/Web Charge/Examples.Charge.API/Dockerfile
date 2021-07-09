#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Web Charge/Examples.Charge.API/Examples.Charge.API.csproj", "Web Charge/Examples.Charge.API/"]
COPY ["Web Charge/Examples.Charge.Infra.CrossCutting.IoC/Examples.Charge.Infra.CrossCutting.IoC.csproj", "Web Charge/Examples.Charge.Infra.CrossCutting.IoC/"]
COPY ["Web Charge/Examples.Charge.Infra.Data/Examples.Charge.Infra.Data.csproj", "Web Charge/Examples.Charge.Infra.Data/"]
COPY ["Web Charge/Examples.Charge.Domain/Examples.Charge.Domain.csproj", "Web Charge/Examples.Charge.Domain/"]
COPY ["Web Charge/Examples.Charge.Application/Examples.Charge.Application.csproj", "Web Charge/Examples.Charge.Application/"]
RUN dotnet restore "Web Charge/Examples.Charge.API/Examples.Charge.API.csproj"
COPY . .
WORKDIR "/src/Web Charge/Examples.Charge.API"
RUN dotnet build "Examples.Charge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Examples.Charge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Examples.Charge.API.dll"]