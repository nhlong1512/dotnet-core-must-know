# Entity Framework Code First

## The APIs in the project
* Get all books (**`GET`**)
## The used packages
```cs
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlSever
Microsoft.EntityFrameworkCore.Tools
```
## ⚡ Installation & Run

### Setup database
First, you need to create a database named `EntityFrameworkCodeFirst` and declare the `DefaultConnectionString`
in the `appsettings.json` file. In my case:
>**appsetings.json**
```sh
...
"ConnectionStrings": {
    "DefaultConnectionString": "Data Source=.;Initial Catalog=BookLibraryCodeFirst;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  ...
```
### Go to EntityFrameworkCodeFirst project
Make sure that you declare `seeddata` in `Program.cs` file. In my case:
>**Program.cs**
```cs
...
builder.Services.AddTransient<Seed>();
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}
...
```
<br>

Make sure that you have deleted `Migrations` folder. <br>
Open `Package Manager Console` and run:
>Run the following commands:
```sh
Add-Migration InitialCreate
Drop-database
Update-database
```
After successfully running without errors, you need to open the `terminal` within the project directory and execute:
>Run the following command:
```sh
cd EntityFrameworkCodeFirst
dotnet run seeddata
```
>Finally, run the following command:
```sh
dotnet run
```
I hope you can run these commands without encountering any errors.

## 🛠️ Troubleshooting
If you encounter errors, you can try delete the `obj` folder and `bin` folder in the project, and then run the `README.md` document again.
