# StringCalculator
This project is built with .Net 9.0-preview: https://dotnet.microsoft.com/en-us/download/dotnet/9.0

## Build
Build the project by running the followings
```
dotnet build
```

## Run the Application (Console Input)
```
dotnet run --project StringCalculator [--delimiter='xxx'][--negatives-ok][--upper-bound=OOO]
```
Use Ctrl-C to exit the application

##### Example 1
```
Enter numbers to add. Press Ctrl+C to exit.
Input: 2,7,10001,55,##,7
2+7+0+55+0+7 = 71
```

##### Example 2
```
dotnet run --project StringCalculator --delimiter='[*][!!][r9r]' --negatives-ok --upper-bound=2000
Enter numbers to add. Press Ctrl+C to exit.
Input: 11r9r22*hh*33!!44*2001!!-500
Result: 11+22+0+33+44+0+-500 = -390
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