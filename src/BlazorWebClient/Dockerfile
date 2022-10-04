FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#
# copy csproj and restore as distinct layers
COPY ./BlazorWebClient/BlazorWebClient.csproj ./BlazorWebClient/
COPY ../JHipster.NetLite.Dto/*.csproj ./JHipster.NetLite.Dto/

RUN dotnet restore ./BlazorWebClient/BlazorWebClient.csproj
#
# copy everything else and build app
COPY ./BlazorWebClient/. ./BlazorWebClient/
COPY ./JHipster.NetLite.Dto/. ./JHipster.NetLite.Dto/
#
WORKDIR /src/BlazorWebClient

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish
#
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .