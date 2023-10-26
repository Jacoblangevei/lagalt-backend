# lagalt-backend
## Introduction
Lagalt .NET backend code for case project automn 2023. 

## Prerequisites
Before getting started with the project, you'll need a development environment for the code. In this project, we utilized Visual Studio as our primary integrated development environment (IDE).

## Installation
1. Clone this repository to your local machine `git clone https://github.com/Jacoblangevei/lagalt-backend`
2. Configure your database connection and any necessary settings.
  1. To connect to SSMS, add this to LagaltDbContext
   `protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=YOUR DATA SOURCE;Initial Catalog=LagaltDB;Integrated Security=True;");
    }  `
   2. Open project manager console and write the following commands `add-migration migrationname` and then `update-database`
   3. The database should now be in SSMS
4. Build and run the Lagalt backend using the .NET SDK.

## Usage
The backend API is documented using Swagger, which provides a user-friendly interface to interact with our endpoints. To access and use Swagger, you have to do the following:
1. Build and run the application. Make sure that you are connected to the database.
2. When running, you will be automatically taken to the URL.
3. Here you can choose which methods to use in the controllers. Select an endpint, enter the needed paramters and change the JSON body as wanted.
   - Some endpoints require being autorized (logged in) or being the owner. For these methods, you can use postman to test. If you are testing these endpoints, ensure you have included the necessary authorization tokens or credentials.
