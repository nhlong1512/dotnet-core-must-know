# Patch API

## The APIs in the project
* Get all books (**`GET`**)
* Update a book with PATCH method (**`PATCH`**)
## The used packages
```cs
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlSever
Microsoft.EntityFrameworkCore.Tools
AutoMapper.Extensions.Microsoft.DependencyInjection
Microsoft.AspNetCore.JsonPatch
Microsoft.AspNetCore.Mvc.NewtonSoftJson
Swashbuckle.AspNetCore.NewtonSoft
```


## ⚡ Installation & Run

### Setup database

* Open the file `BookLibrary.sql` and run it to create the database for database-first

* Connect the project to the `BookLibrary.sql` database. In my case, `DefaultConnectString` is as follows:
```sql
"ConnectionStrings": {
    "DefaultConnectionString": "Data Source=.;Initial Catalog=BookLibrary;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;"
  },
```
You need to add the `DefaultConnectionString` to the `appsettings.json` file in order to establish a connection with the `MSSQL Server` database for the project.

### Go to PatchAPI project
Open `Package Manager Console` and run:
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
## 🛠️ Troubleshooting
If you encounter errors, you can try delete the `obj` folder and `bin` folder in the project, and then run the `README.md` document again.