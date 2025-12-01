FROM mcr.microsoft.com/dotnet/sdk:10.0 AS final

ARG BUILD_CONFIGURATION=Release

WORKDIR /app

COPY ["test-repo1/test-repo1.csproj", "test-repo1/"]
RUN dotnet restore "test-repo1/test-repo1.csproj"

COPY . .
WORKDIR "/app/test-repo1"
RUN dotnet build "./test-repo1.csproj" -c $BUILD_CONFIGURATION -o /app/build

RUN dotnet publish "./test-repo1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

WORKDIR /app/publish

CMD ["sleep", "infinity"]
