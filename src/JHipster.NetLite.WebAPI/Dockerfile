FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
#
# copy csproj and restore as distinct layers
COPY JHipster.NetLite.Application/*.csproj ./JHipster.NetLite.Application/
COPY JHipster.NetLite.Core/*.csproj ./JHipster.NetLite.Core/
COPY JHipster.NetLite.Domain/*.csproj ./JHipster.NetLite.Domain/ 
COPY JHipster.NetLite.Domain.Services/*.csproj ./JHipster.NetLite.Domain.Services/
COPY JHipster.NetLite.Dto/*.csproj ./JHipster.NetLite.Dto/
COPY JHipster.NetLite.Infrastructure/*.csproj ./JHipster.NetLite.Infrastructure/
COPY JHipster.NetLite.WebAPI/*.csproj ./JHipster.NetLite.WebAPI/
#
RUN dotnet restore ./JHipster.NetLite.WebAPI/*.csproj
#
# copy everything else and build app
COPY JHipster.NetLite.Application/. ./JHipster.NetLite.Application/
COPY JHipster.NetLite.Core/. ./JHipster.NetLite.Core/
COPY JHipster.NetLite.Domain/. ./JHipster.NetLite.Domain/ 
COPY JHipster.NetLite.Domain.Services/. ./JHipster.NetLite.Domain.Services/
COPY JHipster.NetLite.Dto/. ./JHipster.NetLite.Dto/
COPY JHipster.NetLite.Infrastructure/. ./JHipster.NetLite.Infrastructure/
COPY JHipster.NetLite.WebAPI/. ./JHipster.NetLite.WebAPI/
#
WORKDIR /app/JHipster.NetLite.WebAPI

RUN dotnet publish -c Release -o out
#
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
#
COPY --from=build /app/JHipster.NetLite.WebAPI/out ./
ENTRYPOINT ["dotnet", "JHipster.NetLite.WebAPI.dll", "--environment=Development"]