FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WindowManipulator/WindowManipulator.csproj", "WindowManipulator/"]
RUN dotnet restore "WindowManipulator/WindowManipulator.csproj"
COPY . .
WORKDIR "/src/WindowManipulator"
RUN dotnet build "WindowManipulator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WindowManipulator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WindowManipulator.dll"]
