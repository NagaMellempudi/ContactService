#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY Contact.Service/Contact.Service.csproj Contact.Service/
RUN dotnet restore "Contact.Service/Contact.Service.csproj"
COPY . .
WORKDIR "/src/Contact.Service"
RUN dotnet build "Contact.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.Service.dll"]
