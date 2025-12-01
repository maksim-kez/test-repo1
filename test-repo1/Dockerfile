FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
WORKDIR /app
USER $APP_UID

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["test-repo1/*.csproj", "test-repo1/"]
COPY ["test-repo1.Tests/*.csproj", "test-repo1.Tests/"]

RUN dotnet restore "test-repo1/test-repo1.csproj"
RUN dotnet restore "test-repo1.Tests/test-repo1.Tests.csproj"

COPY . .

WORKDIR "/src/test-repo1"
RUN dotnet build "./test-repo1.csproj" -c $BUILD_CONFIGURATION -o /app/build

WORKDIR "/src/test-repo1.Tests"
RUN dotnet build "./test-repo1.Tests.csproj" -c $BUILD_CONFIGURATION -o /app/test-build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/test-repo1"
RUN dotnet publish "./test-repo1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS final
WORKDIR /app

COPY --from=publish /app/publish ./publish

COPY --from=build /src/test-repo1 ./test-repo1
COPY --from=build /src/test-repo1.Tests ./test-repo1.Tests

CMD ["sleep", "infinity"]
