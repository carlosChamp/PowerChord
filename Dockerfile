#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80


RUN apt-get update \
    && apt-get install -y --allow-unauthenticated \
        libc6-dev \
        libgdiplus \
        libx11-dev \
     && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PowerChords/PowerChords.csproj", "PowerChords/"]
COPY ["Core/Acordes.csproj", "Core/"]
RUN dotnet restore "PowerChords/PowerChords.csproj"
COPY . .
WORKDIR "/src/PowerChords"
RUN dotnet build "PowerChords.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PowerChords.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "PowerChords.dll"]

CMD ASPNETCORE_URLS=http://*:$PORT dotnet PowerChords.dll
