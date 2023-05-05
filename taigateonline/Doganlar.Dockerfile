FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /app

COPY *.sln .
COPY elFinder.NetCore/*.csproj ./elFinder.NetCore/
COPY Taigate.Cms/*.csproj ./Taigate.Cms/
COPY Taigate.Core/*.csproj ./Taigate.Core/
COPY Taigate.Crispy/*.csproj ./Taigate.Crispy/
COPY Taigate.Data/*.csproj ./Taigate.Data/
COPY Taigate.Mongo/*.csproj ./Taigate.Mongo/

RUN dotnet restore

COPY elFinder.NetCore/. ./elFinder.NetCore/
COPY Taigate.Cms/. ./Taigate.Cms/
COPY Taigate.Core/. ./Taigate.Core/
COPY Taigate.Crispy/. ./Taigate.Crispy/
COPY Taigate.Data/. ./Taigate.Data/
COPY Taigate.Mongo/. ./Taigate.Mongo/


WORKDIR /app/Taigate.Cms
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS runtime
RUN apt-get update
RUN apt-get install -y apt-utils
RUN apt-get install -y libgdiplus
RUN apt-get install -y libc6-dev 
RUN ln -s /usr/lib/libgdiplus.so/usr/lib/gdiplus.dll
RUN apt-get update && apt-get install -y \
curl
WORKDIR /app
COPY --from=build /app/Taigate.Cms/out ./
ENTRYPOINT ["dotnet", "Taigate.Cms.dll"]
