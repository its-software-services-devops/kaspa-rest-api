ARG version
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG version

WORKDIR /install

RUN apt-get -y update \
    && apt-get -y install --no-install-recommends curl unzip \
    && apt-get clean

WORKDIR /source

RUN pwd; ls -lrt;
# copy csproj and restore as distinct layers
COPY kaspa-api/*/* ./kaspa-api/
COPY kaspa-rest-api.sln .

RUN cd kaspa-api; pwd; ls -lrt; 
RUN dotnet restore kaspa-rest-api.csproj
RUN dotnet publish kaspa-rest-api.csproj -c release -o /app --no-restore -p:PackageVersion=${version}

##### final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0

RUN apt-get -y update \
    && apt-get -y install --no-install-recommends curl \
    && apt-get clean

WORKDIR /app
COPY --from=build /app .
RUN ls -lrt

RUN addgroup --group dotnet --gid 2000 \
&& adduser \    
    --uid 1000 \
    --gid 2000 \
    "dotnet"
RUN chown dotnet:dotnet /app
USER dotnet:dotnet 

EXPOSE 8080
ENV ASPNETCORE_URLS="http://*:8080"
ENTRYPOINT ["dotnet", "kaspa-rest-api.dll"]
