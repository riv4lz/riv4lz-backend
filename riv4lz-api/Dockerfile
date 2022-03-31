# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 as BUILD
WORKDIR /app

COPY . .

RUN dotnet restore 
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

ENTRYPOINT ["dotnet", "aspnetapp.dll"]
