FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY ./riv4lz-api/riv4lz.casterApi/bin/Release/net6.0 app/publish
WORKDIR app/publish
ENTRYPOINT ["dotnet", "riv4lz.casterApi.dll"]