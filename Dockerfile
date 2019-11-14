FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS build

WORKDIR /app

RUN apt-get update && \
    apt-get upgrade -y && \
    apt-get install -y nodejs && \
    yes | apt-get install wget && \
    yes | wget -q https://packages.microsoft.com/config/ubuntu/16.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
    dpkg -i packages-microsoft-prod.deb && \
    apt-get update && apt-get upgrade -y && \
    apt-get install apt-transport-https && \
    apt-get update && \
    yes | apt-get install dotnet-sdk-3.0
    

COPY . /app

CMD dotnet tool install -g dotnet-aspnet-codegenerato && \
    dotnet restore && \
    dotnet publish -c Release -o out && \
    dotnet build && \
    dotnet watch run

ENTRYPOINT ["dotnet", "watch", "run", "--no-restore", "--urls", "http://*:5000"]

EXPOSE 5000