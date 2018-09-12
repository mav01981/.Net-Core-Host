# .Net Core 2.1 Windows Service with HostBuilder

A small example of a generic host based .NET core app as a Windows service with a Timer Service.

## Building and creating a service

### Build and publish

dotnet publish -c Release -r win10-x64

### Define the service

sc create MyFileService binPath= "~\Release\netcoreapp2.1\win10-x64\publish\IHostBuilderAsWindowsService.exe"

### Start the service

sc start MyService

For further details see my blog post [Running a .NET Core Generic Host App as a Windows Service]
