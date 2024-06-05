# CarModel
API Endpoints
1. Upload Records API
This API allows you to upload an Excel file and insert all the records into the database.

Endpoint: /carModel/loadFile
Method: POST
Input: Excel file
Response: 200 OK upon successful insertion of records
2. Retrieve Data API
This API retrieves specific data based on the ModelYear and make_id.

Endpoint: /carModel/getData
Method: POST
Parameters:
make_id: The ID of the make (required)
ModelYear: The year of the model (required)
Response: JSON array of entities that match the filter criteria

EF Core Migrations
This project uses EF Core migrations to manage database schema changes. The following dependencies are required:

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

Database
The project uses SQL Server as the database. Ensure you have SQL Server installed and configured correctly.

