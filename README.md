# GamaLearn LMS
This project was generated with  ASP.NET Core v6
# Info
- Simple library management system with the ability to add, delete, and list books. The application uses .NET Core backend, and an angular 16 frontend and both were hosted on Azure.
- I Used EF Core v6 with the Code First approach to create the database schema and utilize LINQ for data access. Implement middleware for logging and auth. Use the Repository Pattern for data access and utilize Dependency Injection. Document your APIs using Swagger

# Live URL
[Gamalearn Azure Appservice](https://gamalearn-lms.azurewebsites.net/)

_**Note**: Complete deployment with Database was not done since Azure free trial was used for this project._

## Code First Migrations
- Below command was used to generate migrations
```
dotnet-ef migrations add InitialCreate --project "D:\Projects\Library Managment System\Infrastructure\LMS.DataAccessLayer" --context LMSDbContext --verbose
```
- Migrations are located in the following folder `../Infrastructure/LMS.DataAccessLayer/Migrations`

## Additional Information
### Azure Pipelines
#### Continuous Integration
[Gamalearn Build Pipeline](https://dev.azure.com/pipeline-link-goes-here)

#### Continous Deployment
[Gamalearn Release Pipeline](https://dev.azure.com/release-link-goes-here)

### Unit Testing
Testing was implemented for a few methods.
