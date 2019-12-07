FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5002
ENV ASPNETCORE_URLS=http://+:5001

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Banking.Simulator/Banking.Simulator.csproj Banking.Simulator/
RUN dotnet restore Banking.Simulator/Banking.Simulator.csproj
COPY . .
WORKDIR /src/Banking.Simulator
RUN dotnet build Banking.Simulator.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Banking.Simulator.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Banking.Simulator.dll"]
