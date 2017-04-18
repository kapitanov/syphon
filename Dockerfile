FROM microsoft/dotnet:1.1-sdk
COPY . /app
RUN dotnet restore
RUN dotnet build
WORKDIR /app/src/syphon-telegram
ENTRYPOINT ["dotnet", "run"]