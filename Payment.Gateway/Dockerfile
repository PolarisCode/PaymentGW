FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Payment.API/Payment.API.csproj", "Payment.API/"]
RUN dotnet restore "Payment.API/Payment.API.csproj"
COPY . .
WORKDIR "/src/Payment.API"
RUN dotnet build "Payment.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Payment.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payment.API.dll"]