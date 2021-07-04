FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app --no-restore

RUN rm -rf /etc/localtime && ln -s /usr/share/zoneinfo/Asia/Tehran /etc/localtime

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
LABEL com.centurylinklabs.watchtower.enable="true"
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "RaymonApiTaskTests.dll"]
