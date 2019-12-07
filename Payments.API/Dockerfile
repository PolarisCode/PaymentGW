FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001/tcp
ENV ASPNETCORE_URLS=http://+:5001

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Payments.API/Payments.API.csproj Payments.API/
RUN dotnet restore Payments.API/Payments.API.csproj
COPY . .
WORKDIR /src/Payments.API
RUN dotnet build Payments.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Payments.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Payments.API.dll"]
