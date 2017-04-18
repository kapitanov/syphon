FROM microsoft/dotnet:1.1-sdk
COPY . /app
RUN cd /app && dotnet restore && dotnet build
WORKDIR /app/src/syphon-telegram
ENTRYPOINT ["dotnet", "run"]