# Repository Pattern CRUD with Book Library Management

## Introduction
A **Repository pattern** is a design pattern that mediates data from and to the Domain and Data Access Layers ( like Entity Framework Core / Dapper). Repositories are classes that hide the logics required to store or retreive data. Thus, our application will not care about what kind of ORM we are using, as everything related to the ORM is handled within a repository layer. This allows you to have a cleaner seperation of concerns. Repository pattern is one of the heavily used Design Patterns to build cleaner solutions.

## The APIs in the project
* Get all books (**`GET`**)
* Get a book by Id (**`GET`**)
* Create a book (**`POST`**)
* Update a book with PUT method (**`PUT`**)
* Update a book with PATCH method (**`PATCH`**)
* Delete a book by Id (**`DELETE`**)
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

Open the file `BookLibrary.sql` and run it to create the database for database-first

### Go to RepositoryPatternCRUD project
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
