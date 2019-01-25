FROM microsoft/dotnet:2.2-sdk AS build
COPY . /aimooc
WORKDIR /aimooc
EXPOSE 80/tcp
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
RUN dotnet publish -c Release -o publish/
WORKDIR /aimooc/publish
ENTRYPOINT ["dotnet", "aimooc.dll"]