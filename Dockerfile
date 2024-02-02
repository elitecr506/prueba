#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/Ecommerce.SOS.Gateway/Ecommerce.SOS.Gateway.csproj", "Presentation/Ecommerce.SOS.Gateway/"]
COPY ["Core/Ecommerce.SOS.Application/Ecommerce.SOS.Application.csproj", "Core/Ecommerce.SOS.Application/"]
COPY ["Core/Elite.Ecommerce.SOS.Domain/Ecommerce.SOS.Domain.csproj", "Core/Elite.Ecommerce.SOS.Domain/"]
COPY ["Infrastructure/Ecommerce.SOS.Datasources/Ecommerce.SOS.Datasources.csproj", "Infrastructure/Ecommerce.SOS.Datasources/"]
COPY ["Infrastructure/Ecommerce.SOS.Services/Ecommerce.SOS.Services.csproj", "Infrastructure/Ecommerce.SOS.Services/"]
RUN dotnet restore "Presentation/Ecommerce.SOS.Gateway/Ecommerce.SOS.Gateway.csproj"
COPY . .
WORKDIR "/src/Presentation/Ecommerce.SOS.Gateway"
RUN dotnet build "Ecommerce.SOS.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.SOS.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.SOS.Gateway.dll"]
