# StringCalculator
This project is built with .Net 9.0-preview: https://dotnet.microsoft.com/en-us/download/dotnet/9.0

## Build
Build the project by running the followings
```
dotnet build
```

## Tests
Please make sure you have xUnit installed

##### Install necessary packages and restore
```
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package Microsoft.NET.Test.Sdk
dotnet restore
```

##### Run the tests
```
dotnet test
```