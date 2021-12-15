#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

#ENV ASPNETCORE_URLS http://*:44319

#ENV ASPNETCORE_ENVIRONMENT=Development #Add this line.

#EXPOSE 44319

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GoPlanner.Plans/GoPlanner.Plans.csproj", "GoPlanner.Plans/"]
RUN dotnet restore "GoPlanner.Plans/GoPlanner.Plans.csproj"
COPY . .
WORKDIR "/src/GoPlanner.Plans"
RUN dotnet build "GoPlanner.Plans.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GoPlanner.Plans.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GoPlanner.Plans.dll"]
