# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY ["src/Ecom.Users.API/Ecom.Users.API.csproj", "src/Ecom.Users.API/"]
COPY ["src/Ecom.Users.Application/Ecom.Users.Application.csproj", "src/Ecom.Users.Application/"]
COPY ["src/Ecom.Users.Domain/Ecom.Users.Domain.csproj", "src/Ecom.Users.Domain/"]
COPY ["src/Ecom.Users.Infrastructure/Ecom.Users.Infrastructure.csproj", "src/Ecom.Users.Infrastructure/"]

RUN dotnet restore "src/Ecom.Users.API/Ecom.Users.API.csproj"

# Copy source code - fixing the path issue
COPY . .
WORKDIR "/src/src/Ecom.Users.API"
RUN dotnet build "Ecom.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ecom.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecom.Users.API.dll"]