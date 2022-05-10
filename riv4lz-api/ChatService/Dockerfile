FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app




FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ChatService/ChatService.csproj", "ChatService/"]
RUN dotnet restore "ChatService/ChatService.csproj"
COPY . .
WORKDIR "/src/ChatService"
RUN dotnet build "ChatService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChatService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5000
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChatService.dll"]
