# Products API and Web App  

## Description  
This project consists of a **.NET 9.0** API and a web app.

## Prerequisites  
Before running the project, this is needed:  
1. **Local SQL Server** on your machine.  
2. **.NET 9.0 SDK** installed.  

## Getting Started  

Follow these steps to set up and run the project locally.

---

## Backend: **ProductBackend/ProductApi**  

### 1 Configure the API  
1. Open **ProductBackend** and create an `appsettings.Development.json` file or just settings to launchsettings.json.  
2. Add the following configuration (replace placeholders with actual values):  

   ```json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     },
     "ConnectionStrings": {
       "DefaultConnection": "Server=*YOUR_SERVER*;Database=*YOUR_DATABASE*;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

### 2 Apply Database Migrations  
Run the following commands to create tables and seed the database:  

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3 Start the API  
Navigate to the **ProductBackend** directory and run:  

```bash
dotnet run
```

---

## Frontend: **ProductsClientAppBlazor**  

### 1 Configure the Web App  
1. Open **ProductsClientAppBlazor** and create an `appsettings.Development.json` file or just settings to launchsettings.json.  
2. Add the following configuration (replace the API port with the correct value):  

   ```json
   {
     "ProductsBaseUrl": "https://localhost:*YOUR_API_PORT*",
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     }
   }
   ```

### 2 Start the Web App  
Navigate to the **ProductsClientAppBlazor** directory and run:  

```bash
dotnet run
```

---

## Notes 🚀  
No error handling is currently implemented! Proceed with caution ;)
