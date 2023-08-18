# CRUD Basic with Book Library Management
## The used packages
```cs
Microsoft.EntityFrameworkCore
Microsoft.EntiryFrameworkCore.Design
Microsoft.EntiryFrameworkCore.SqlSever
Microsoft.EntityFrameworkCore.Tools
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.AspNetCore.JsonPatch
Microsoft.AspNetCore.Mvc.NewtonSoftJson
Swashbuckle.AspNetCore.NewtonSoft
```

## Install & Run

### Setup database

Open the file **BookLibrary.sql** and run it to create the database for database-first

### Go to EntityFrameworkDatabaseFirst project
Open **Package Manager Console** and run:
>run
```sh
Scaffold-DbContext [-Connection] [-Provider] [-OuputDir] [-Context] [-Schemas>] [-Tables>] [-DataAnnotations] [-Force] [-Project] [-StartupProject] [<CommonParameters>]
```
In my case:
>run
```sh
Scaffold-DbContext -Connection name=DefaultConnectionString Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models -context DataContext -f -contextDir Data -DataAnnotations
```
>run 
```sh
dotnet run
```

