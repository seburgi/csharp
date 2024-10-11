FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./Src/LogisticsRestApi/LogisticsRestApi.csproj . 
# ["Src/LogisticsRestApi/LogisticsRestApi.csproj", "LogisticsRestApi/"]
RUN dotnet restore "LogisticsRestApi.csproj"
COPY . /src
WORKDIR "/src/LogisticsRestApi"
RUN ls 
RUN dotnet build "/src/Src/LogisticsRestApi/LogisticsRestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/Src/LogisticsRestApi/LogisticsRestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "LogisticsRestApi.dll"]
