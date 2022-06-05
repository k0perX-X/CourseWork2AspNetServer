#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5432

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
RUN dotnet dev-certs https --trust
WORKDIR /src
COPY ["CourseWork2AspNetServer/CourseWork2AspNetServer.csproj", "CourseWork2AspNetServer/"]
RUN dotnet restore "CourseWork2AspNetServer/CourseWork2AspNetServer.csproj"
COPY . .
WORKDIR "/src/CourseWork2AspNetServer"
RUN dotnet build "CourseWork2AspNetServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseWork2AspNetServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "CourseWork2AspNetServer.dll"]