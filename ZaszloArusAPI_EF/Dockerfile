#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ZaszloArusAPI_EF/ZaszloArusAPI_EF.csproj", "ZaszloArusAPI_EF/"]
RUN dotnet restore "ZaszloArusAPI_EF/ZaszloArusAPI_EF.csproj"
COPY . .
WORKDIR "/src/ZaszloArusAPI_EF"
RUN dotnet build "ZaszloArusAPI_EF.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZaszloArusAPI_EF.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZaszloArusAPI_EF.dll"]