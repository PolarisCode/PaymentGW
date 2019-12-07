FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Payment.Gateway/Payment.Gateway.csproj Payment.Gateway/
RUN dotnet restore Payment.Gateway/Payment.Gateway.csproj
COPY . .
WORKDIR /src/Payment.Gateway
RUN dotnet build Payment.Gateway.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Payment.Gateway.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payment.Gateway.dll"]
