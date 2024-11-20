FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as base
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base

WORKDIR /app

RUN dotnet dev-certs https
