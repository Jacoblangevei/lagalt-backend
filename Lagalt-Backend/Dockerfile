FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src/
COPY ["Lagalt-Backend/Lagalt-Backend.csproj", "."]
RUN dotnet restore "./Lagalt-Backend.csproj"
COPY . .
WORKDIR "/src/Lagalt-Backend"
RUN dotnet build "Lagalt-Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lagalt-Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lagalt-Backend.dll"]