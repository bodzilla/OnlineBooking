FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OnlineBooking.Web/OnlineBooking.Web.csproj", "OnlineBooking.Web/"]
RUN dotnet restore "OnlineBooking.Web/OnlineBooking.Web.csproj"
COPY . .
WORKDIR "/src/OnlineBooking.Web"
RUN dotnet build "OnlineBooking.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OnlineBooking.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OnlineBooking.Web.dll"]
