FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /app
EXPOSE 80
COPY MovieApp.Application/*.csproj MovieApp.Application/
COPY MovieApp.Domain/*.csproj MovieApp.Domain/
COPY MovieApp.Infrastructure/*.csproj MovieApp.Infrastructure/
COPY MovieApp.Infrastructure.IoC/*.csproj MovieApp.Infrastructure.IoC/
COPY MovieApp.Api/*.csproj MovieApp.Api/
RUN dotnet restore  MovieApp.Api/*.csproj
COPY . .
RUN dotnet publish MovieApp.Api/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MovieApp.Api.dll" ]