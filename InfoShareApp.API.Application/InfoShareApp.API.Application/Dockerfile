FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["InfoShareApp.API.Application/InfoShareApp.API.Application.csproj", "InfoShareApp.API.Application/"]
RUN dotnet restore "InfoShareApp.API.Application/InfoShareApp.API.Application.csproj"
COPY . .
WORKDIR "/src/InfoShareApp.API.Application"
RUN dotnet build "InfoShareApp.API.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InfoShareApp.API.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InfoShareApp.API.Application.dll"]