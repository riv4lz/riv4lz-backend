# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 
WORKDIR /app
ENV PATH $PATH:/root/.dotnet/tools

COPY . .

RUN dotnet restore "riv4lz-api"
RUN dotnet build "riv4lz-api" -c Release -o /app/build
RUN dotnet publish "riv4lz-api" -c Release -o /app/publish
RUN dotnet tool install -g dotnet-ef 

ENTRYPOINT ["dotnet", "riv4lz-api/riv4lz-api.dll"]