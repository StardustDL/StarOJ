# StarOJ

![CI](https://github.com/StardustDL/StarOJ/workflows/CI/badge.svg) ![CD](https://github.com/StardustDL/StarOJ/workflows/CD/badge.svg) ![License](https://img.shields.io/github/license/StardustDL/StarOJ.svg)

An online-judge platform based on Judge0.

![](https://repository-images.githubusercontent.com/278850268/228cf880-c43b-11ea-9876-45d254c8a9da)

## Screenshots

![](https://raw.githubusercontent.com/StardustDL/own-staticfile-hosting/master/StardustDL/StarOJ/images/demo_ide.png)

## Install

> StarOJ needs Judge0 service.

Use StarOJ's docker image:

```sh
docker pull stardustdl/staroj:latest
docker run -d -p 8000:80 stardustdl/staroj:latest
```

You can use volume to apply settings:

```sh
docker run -d \
  -v $PWD/appsettings.json:/app/appsettings.json \
  -v $PWD/manifest.json:/app/wwwroot/manifest.json \
  -p 8000:80 stardustdl/staroj:latest
```

## Build

1. Install .NET Core SDK 3.1, NodeJS 12.x and npm.
2. Install Gulp & Libman
3. Install psake

```ps1
npm install -g gulp
dotnet tool install --global Microsoft.Web.LibraryManager.Cli
Set-PSRepository -Name PSGallery -InstallationPolicy Trusted; Install-Module -Name psake
```

4. Restore dependencies

Add NuGet source: https://sparkshine.pkgs.visualstudio.com/StardustDL/_packaging/feed/nuget/v3/index.json.

```ps1
Invoke-psake Restore
```

1. Build project

```ps1
Invoke-psake Build
```

## Test & Benchmark

```sh
Invoke-psake CI
```
