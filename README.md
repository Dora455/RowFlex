
# RowFlex - An Application for Rowing Coaches and Athletes

## Project Overview
RowFlex is an innovative application developed by students of Jagiellonian University, designed to support coaches and athletes of the university's rowing section. The project aims to streamline training organization, track athlete progress, and manage sporting events in a clear and user-friendly way.

## Prerequisites
To run this project, ensure the following are installed and set up:
- **.NET 8.0**
- **Entity Framework CLI**: Install globally with:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### Setting Up the Database
1. **Ensure your SQL Server is running**, and create a new database if needed.  
   You can use SQL Server Management Studio (SSMS) or any SQL client to create a database manually, or ensure the connection string points to an existing database.

2. **Configure the connection string** in the `appsettings.json` file of the project:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;"
     }
   }
3. **Apply Migrations**:
   After setting up the connection string, run the following command to apply the initial database migrations:
   ```bash
   dotnet ef --project RowFlex migrations add InitialCreate
   dotnet ef --project RowFlex database update
   ```

---

## Running the Project
To start the application, use the following command:
```bash
dotnet watch run
```

---

## Design Patterns

This project incorporates several key design patterns to ensure a clean, maintainable, and scalable architecture:

### Architectural Patterns
- **Service Layer**: Encapsulates business logic to ensure separation from data access logic. ``` /Data/DataBaseService.cs ```
- **Table Data Gateway**: Manages database operations for a single table, providing a clean interface. ```/Data/ClubGataway.cs ```
- **MVC (Model View Controller)**: Separates application logic into three interconnected components for better modularity.
- **Template View**: Provides reusable templates for rendering dynamic content on the front end. ``` @page "/training-plans/{planId:int}/participants" ```

### State Management
- **Server Session State**: Maintains user session data on the server for better security and persistence. ``` /Program.cs ```

### Dependency Management
- **Dependency Injection**: Decouples components by injecting their dependencies, improving testability and flexibility.

### Object Relational Mapping (ORM)
- **Data Mapper**: Transfers data between objects and the database while maintaining separation of concerns.
- **Foreign Key Mapping**: Handles relationships between entities via foreign keys. ``` /Models/WeightMeasurements.cs ```
- **Association Table Mapping**: Maps many-to-many relationships between entities.
``` /Models/Presence.cs ```
### Transaction Management
- **Unit of Work**: Manages changes to data as a single transactional unit to ensure consistency.

### Performance Optimization
- **Lazy Loading**: Delays the initialization of objects until they are needed, improving performance.

### Identity and Query Patterns
- **Identity Field**: Ensures each database entity has a unique identifier.
- **Query Object**: Encapsulates database queries in reusable, maintainable objects. ``` /Data/UserQuery ```

---

## Key Features
- **Separate Interfaces for Coaches and Athletes**: Intuitive and user-friendly interfaces tailored to different user roles.
- **User Registration**:
  - **Coaches**: Registration requires approval by an administrator.
  - **Athletes**: Registration requires approval by an administrator or a coach.
- **Training Management**:
  - Adding and editing training plans.
  - Tracking attendance at training sessions.
  - Creating training lists for assigning athletes to boats based on their skills.
- **Event Calendar**: Adding events such as competitions and training sessions in a text-based format.
- **Performance Tracking**:
  - Monitoring training progress on rowing ergometers with data analysis.
  - Managing athlete weight categories with mandatory monthly weigh-ins (configurable by the coach).
- **Progress Analysis**: Coaches can review athlete progress in a detailed table format.
- **News Section**: A dedicated area for important updates and announcements related to the section.

---

## Technologies
RowFlex is being developed using **C#** and the **Blazor framework**. Additionally, we are utilizing **Jira** for project management and task tracking. The application will leverage modern design patterns to ensure modularity, scalability, and maintainable code.
