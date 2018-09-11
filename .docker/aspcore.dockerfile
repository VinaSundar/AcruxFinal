FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
MAINTAINER 	Vina
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./WebUI/MyHealth/WebUI/MyHealth.csproj ./
RUN dotnet restore 
# Vnext.Web/Vnext.Web.csproj
COPY ./WebUI/MyHealth/ ./
# RUN dotnet build Vnext.Web.csproj -c Release -o /app
# WORKDIR /src/Vnext.Web

FROM build AS publish
RUN dotnet publish MyHealth.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
RUN apt-get update && apt-get install -y net-tools iputils-ping
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MyHealth.dll"]