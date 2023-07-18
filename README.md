# GamaLearn LMS
This project was generated with  ASP.NET Core v6
# Info
- Simple library management system with the ability to add, delete, and list books. The application uses .NET Core backend, and an angular 16 frontend and both were hosted on Azure.
- I Used EF Core v6 with the Code First approach to create the database schema and utilize LINQ for data access. Implement middleware for logging and auth. Use the Repository Pattern for data access and utilize Dependency Injection.

# Live URL
[Gamalearn Azure Appservice](https://gamalearn-lms.azurewebsites.net/)

_**Note**: Complete deployment with Database was not done since Azure free trial was used for this project._

# Get Started
1. Install [.NET SDK v6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
2. Install [Visual Studio](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&passive=false&cid=2030)
3. Clone project
4. Build the solution by Ctrl + B
5. Run the solution by F5 key.

# Code First Migrations
- Below command was used to generate migrations
```
dotnet-ef migrations add InitialCreate --project "D:\Projects\Library Managment System\Infrastructure\LMS.DataAccessLayer" --context LMSDbContext --verbose
```
- Migrations are located in the following folder `../Infrastructure/LMS.DataAccessLayer/Migrations`

# Additional Information
## Azure Pipelines
### Continuous Integration
[Gamalearn Build Pipeline](https://dev.azure.com/MahmoudKamal-Projects/GamaLearn-LMS/_build?definitionId=4)

### Continous Deployment
[Gamalearn Release Pipeline](https://dev.azure.com/MahmoudKamal-Projects/GamaLearn-LMS/_release?_a=releases&view=mine&definitionId=2)

## Unit Testing
Testing was implemented for a few methods.
