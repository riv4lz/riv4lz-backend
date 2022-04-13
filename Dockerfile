# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
COPY . .
RUN dotnet restore "riv4lz-api"

RUN dotnet publish "riv4lz-api" -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "riv4lz.casterApi.dll"]