# Multi-stage Dockerfile for ASP.NET Core personal page
# Optimized for Azure App Service for Containers

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy solution and project files
COPY ["PersonalPage.sln", "."]
COPY ["src/PersonalPage/PersonalPage.csproj", "src/PersonalPage/"]
COPY ["tests/PersonalPage.Tests/PersonalPage.Tests.csproj", "tests/PersonalPage.Tests/"]

# Restore dependencies
RUN dotnet restore

# Copy source code
COPY . .

# Build
RUN dotnet build --configuration Release --no-restore

# Run tests
RUN dotnet test --configuration Release --no-build --verbosity normal

# Publish
RUN dotnet publish --configuration Release --output /app/publish --no-build

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime

# Install ca-certificates for HTTPS
RUN apk add --no-cache ca-certificates

# Create non-root user for security
RUN addgroup -S appgroup && adduser -S appuser -G appgroup

WORKDIR /app
EXPOSE 8080
EXPOSE 8443

# Copy published app from build stage
COPY --from=build --chown=appuser:appgroup /app/publish .

# Set environment variables
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_HTTP_PORT=8080

# Use non-root user
USER appuser

# Health check
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
  CMD wget --no-verbose --tries=1 --spider http://localhost:8080/ || exit 1

# Run application
ENTRYPOINT ["dotnet", "PersonalPage.dll"]
