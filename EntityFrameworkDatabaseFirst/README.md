# Entity Framework Database First
## The APIs in the project
* Get all books (**`GET`**)
## The used packages
```cs
Microsoft.EntityFrameworkCore
Microsoft.EntiryFrameworkCore.Design
Microsoft.EntiryFrameworkCore.SqlSever
Microsoft.EntityFrameworkCore.Tools
```

## ⚡ Installation & Run

### Database Setup

Open the file `BookLibrary.sql` and run it to create the database for database-first 

### Go to EntityFrameworkDatabaseFirst project
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
