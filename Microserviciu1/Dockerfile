#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Microserviciu1/Microserviciu1.csproj", "Microserviciu1/"]
RUN dotnet restore "Microserviciu1/Microserviciu1.csproj"
COPY . .
WORKDIR "/src/Microserviciu1"
RUN dotnet build "Microserviciu1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microserviciu1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microserviciu1.dll"]