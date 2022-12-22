FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ActorModel.Orleans/ActorModel.Orleans.csproj", "ActorModel.Orleans/"]
RUN dotnet restore "ActorModel.Orleans/ActorModel.Orleans.csproj"
COPY . .
WORKDIR "/src/ActorModel.Orleans"
RUN dotnet build "ActorModel.Orleans.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ActorModel.Orleans.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ActorModel.Orleans.dll"]
