FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS base
WORKDIR /src

COPY **/*.csproj ./

RUN find . -type f -name '*.csproj' -exec dotnet restore {} \;
RUN find . -type f -name '*.csproj' -exec rm {} \;
    
    
FROM base AS publish
COPY . .
RUN dotnet publish -c Release -o ./gRPC-Test.Web/out gRPC-Test.Web/gRPC-Test.Web.csproj
RUN dotnet publish -c Release -o ./gRPC-Test.gRPC/out gRPC-Test.gRPC/gRPC-Test.gRPC.csproj


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS grpc-test-web
WORKDIR /app
EXPOSE 5000
COPY --from=publish /src/gRPC-Test.Web/out/ ./
ENTRYPOINT ["dotnet", "gRPC-Test.Web.dll"]


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS grpc-test-grpc
WORKDIR /app
EXPOSE 50051
COPY --from=publish /src/gRPC-Test.gRPC/out/ ./
# RUN curl -OL http://aka.ms/perfcollect && chmod +x perfcollect && ./perfcollect install
ENTRYPOINT ["dotnet", "gRPC-Test.gRPC.dll"]
