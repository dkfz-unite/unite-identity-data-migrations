FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS restore
ARG USER
ARG TOKEN
WORKDIR /src
RUN dotnet nuget add source https://nuget.pkg.github.com/dkfz-unite/index.json -n github -u ${USER} -p ${TOKEN} --store-password-in-clear-text
COPY ["Unite.Identity.Data.Migrations/Unite.Identity.Data.Migrations.csproj", "Unite.Identity.Data.Migrations/"]
RUN dotnet restore "Unite.Identity.Data.Migrations/Unite.Identity.Data.Migrations.csproj"

FROM restore AS build
COPY . .
WORKDIR "/src/Unite.Identity.Data.Migrations"
RUN dotnet build "Unite.Identity.Data.Migrations.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unite.Identity.Data.Migrations.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unite.Identity.Data.Migrations.dll"]
