FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApiForPostman.csproj", "./"]
RUN dotnet restore "WebApiForPostman.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "WebApiForPostman.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiForPostman.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebApiForPostman.dll
ENTRYPOINT ["dotnet", "WebApiForPostman.dll"]
