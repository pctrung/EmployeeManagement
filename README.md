# Employee Management
Employee Management is a management website for employee management with basic features

# Tech Stack
- ASP.NET 5
- Entity Framework 5.0.13
- Bootstrap 4
- JQuery

# Prerequirements

* Visual Studio 2019
* .NET 5 SDK
* SQL Server

# How To Run
## In Visual Studio

* Open solution in Visual Studio 2019
* Create appsettings.json file to config connection strings in Data layer and MVCSite layer
* Set EmployeeManagement.MVCSite project as Startup Project and build the project
* Run the application

## In Command Line

* Create appsettings.json file to config connection strings in Data layer and MVCSite layer
* Open command line, cd to project and run these code
```
dotnet restore
cd EmployeeManagement.MVCSite
dotnet run
```

## Example appsettings.json file
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=EmplopyeeManagement;Trusted_Connection=True;"
  }
}
```

# UI
![image](https://user-images.githubusercontent.com/44517184/147853735-10ceb343-38fa-41a2-8340-82136a6b2cb7.png)
