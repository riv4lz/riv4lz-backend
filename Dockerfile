# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 as BUILD
WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build
RUN dotnet publish -c Release -o out


ENTRYPOINT ["dotnet", "aspnetapp.dll"]