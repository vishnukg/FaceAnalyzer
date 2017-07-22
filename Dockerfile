FROM microsoft/aspnetcore-build
LABEL name "faceanalyzerapi"
WORKDIR /app
COPY out .                                                                                                                                                                                         
ENV ASPNETCORE_URLS=http://*:${PORT}                                                                                                                                                                 

ENTRYPOINT ["dotnet",  "FaceDetectorApi.dll"]
