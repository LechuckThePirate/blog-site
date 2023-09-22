FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BlogSite.Wasm/BlogSite.Wasm.csproj", "BlogSite.Wasm/"]
RUN dotnet restore "BlogSite.Wasm/BlogSite.Wasm.csproj"
COPY . .
WORKDIR "/src/BlogSite.Wasm"
RUN dotnet build "BlogSite.Wasm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogSite.Wasm.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY ./BlogSite.Wasm/nginx.conf /etc/nginx/nginx.conf