#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
FROM ghcr.io/shimat/opencvsharp/ubuntu20-dotnet6-opencv4.6.0:20220615 AS base
#FROM  ghcr.io/shimat/opencvsharp/ubuntu20-dotnet6sdk-opencv4.6.0:20220615 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ImageProcessingService/ImageProcessingService.csproj", "ImageProcessingService/"]
RUN dotnet restore "ImageProcessingService/ImageProcessingService.csproj"
COPY . .
WORKDIR "/src/ImageProcessingService"
RUN dotnet build "ImageProcessingService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ImageProcessingService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ImageProcessingService.dll"]