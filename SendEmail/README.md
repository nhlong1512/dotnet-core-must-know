# Send an Email via SMTP with MailKit
## Install & Run
### Config info EmailSettings
To run the project, you need to provide the following information in the **appsettings.json** file.

```cs
"EmailSettings": {
    "Email": "Your Email",
    "AppPassword": "Your AppPassword",
    "Host": "smtp.gmail.com",
    "DisplayName": "Your Display Name",
    "Port": 587
}
```
### **Go to SendEmail project in "SendEmail"**
Run API
>run
```sh
dotnet run
```
