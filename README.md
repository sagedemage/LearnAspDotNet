# LearnAspDotNet

Project for learning ASP.NET.

## 1. Setup App Settings
1. Rename `appsettings.Sample.json` to `appsettings.json`
2. Add database password to `WeatherContext` in `appsettings.json`

### 1.1 For example: 
In `Password` variable, add the database password.
```
"ConnectionStrings": {
	"WeatherContext": "Server=127.0.0.1,1433;Database=WeatherContext;User Id=SA;Password=Insert_Database_Password;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

## 2. Connect to SQL Server Express Database
This is the name of the server you want to connect to from SSMS on a **local database**
```
(localdb)\MSSQLLocalDB
```

This is the name of the server you want to connect to from SSMS on a **remote database**
```
pc-name\SQLEXPRESS
```

Connect to docker container of sql server
```
sqlcmd -S 127.0.0.1 -U sa -P Insecurepassword123@
```

## 3. Install Entity Framework Core tools (.NET Core CLI) - [Optional]
```
dotnet tool install --global dotnet-ef
```

## 4. Database Mirgration
Perform database migration via Visual Studio:
```
Add-Migration InitialCreate
Update-Database
```

or via CLI:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## 5. Resources
### 5.1 Documentation
1. [Tutorial: Create a web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio)
2. [Part 4, add a model to an ASP.NET Core MVC app](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-model?view=aspnetcore-7.0&tabs=visual-studio)
3. [Part 5, work with a database in an ASP.NET Core MVC app](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-7.0&tabs=visual-studio)
### 5.2 Installation 
#### 5.21 Download Links
1. [.NET](https://dotnet.microsoft.com/en-us/download)
2. [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
#### 5.22 Articles
3. [Getting Started with SQL Server 2017 Express LocalDB](https://www.mssqltips.com/sqlservertip/5612/getting-started-with-sql-server-2017-express-localdb/)
