FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . ./
RUN dotnet restore "./PockOData.Api/PockOData.Api.csproj"
RUN dotnet publish "./PockOData.Api/PockOData.Api.csproj" -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "PockOData.Api.dll"]