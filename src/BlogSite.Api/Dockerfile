FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BlogSite.Api/BlogSite.Api.csproj", "BlogSite.Api/"]
RUN dotnet restore "BlogSite.Api/BlogSite.Api.csproj"
COPY . .
WORKDIR "/src/BlogSite.Api"
RUN dotnet build "BlogSite.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogSite.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogSite.Api.dll"]
