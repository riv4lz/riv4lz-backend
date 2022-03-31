# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 as BUILD
WORKDIR /app

COPY . .

RUN cd riv4lz-api
RUN dotnet restore riv4lz-api.sln
RUN dotnet build "riv4lz-api/riv4lz.casterApi/riv4lz.casterApi.csproj" -c Release -o /app/build
RUN dotnet publish "riv4lz-api/riv4lz.casterApi/riv4lz.casterApi.csproj" -c Release -o /app/publish

ENTRYPOINT ["dotnet", "aspnetapp.dll"]
