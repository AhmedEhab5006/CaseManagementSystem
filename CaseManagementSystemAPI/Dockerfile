# ===========================
# Stage 1: Build
# ===========================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy entire solution
COPY . .

# Restore dependencies for the solution
RUN dotnet restore CaseManagementSystem.sln

# Publish only the API project
RUN dotnet publish API/API.csproj -c Release -o /app/out

# ===========================
# Stage 2: Run
# ===========================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Configure Render port
ENV ASPNETCORE_URLS=http://+:$PORT

ENTRYPOINT ["dotnet", "CaseManagementSystemAPI.dll"]
