#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DanskAkvakultur.dk.Web/DanskAkvakultur.dk.Web.csproj", "DanskAkvakultur.dk.Web/"]
COPY ["DanskAkvakultur.dk.DataAccess/DanskAkvakultur.dk.DataAccess.csproj", "DanskAkvakultur.dk.DataAccess/"]
COPY ["DanskAkvakultur.dk.Shared/DanskAkvakultur.dk.Shared.csproj", "DanskAkvakultur.dk.Shared/"]
RUN dotnet restore "DanskAkvakultur.dk.Web/DanskAkvakultur.dk.Web.csproj"
COPY . .
WORKDIR "/src/DanskAkvakultur.dk.Web"
RUN dotnet build "DanskAkvakultur.dk.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DanskAkvakultur.dk.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DanskAkvakultur.dk.Web.dll"]