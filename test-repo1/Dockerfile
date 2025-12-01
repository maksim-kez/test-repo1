FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["test-repo1/test-repo1.csproj", "test-repo1/"]
RUN dotnet restore "test-repo1/test-repo1.csproj"

COPY . .

WORKDIR "/src/test-repo1"
RUN dotnet build "./test-repo1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./test-repo1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS final
WORKDIR /app

COPY --from=build /src/test-repo1 ./test-repo1

COPY --from=publish /app/publish ./publish

CMD ["sleep", "infinity"]
