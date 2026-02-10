# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY HireServices/*.csproj ./HireServices/
RUN dotnet restore

# Copy the rest of the source code
COPY HireServices/. ./HireServices/
WORKDIR /app/HireServices

# Build the application
RUN dotnet publish -c Release -o out

# Use the official ASP.NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/HireServices/out ./

# Expose port 80
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "HireServices.dll"]