# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
ENV PATH $PATH:/root/.dotnet/tools

COPY . .

RUN dotnet restore "riv4lz-api"
RUN dotnet build "riv4lz-api" -c Release -o /app/build
RUN dotnet publish "riv4lz-api" -c Release -o /app/publish
RUN dotnet tool install -g dotnet-ef 


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]