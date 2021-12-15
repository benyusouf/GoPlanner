#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

#ENV ASPNETCORE_URLS https://*:5001

#ENV ASPNETCORE_ENVIRONMENT=Development

#EXPOSE 5001


EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GoPlanner.Accounts/GoPlanner.Accounts.csproj", "GoPlanner.Accounts/"]
RUN dotnet restore "GoPlanner.Accounts/GoPlanner.Accounts.csproj"
COPY . .
WORKDIR "/src/GoPlanner.Accounts"
RUN dotnet build "GoPlanner.Accounts.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoPlanner.Accounts.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoPlanner.Accounts.dll"]
