# Scenario

You are a developer working on an existing legacy project.

The project is a RESTful API that provides CRUD operations for a list of students.

The API is built using ASP.NET Core and uses in-memory storage to store the student data.

The project have tests for the API endpoints.
All tests are passing.

You have been tasked with changing the in-memory storage to use a persistent storage mechanism.

## You need to implement the following

1. Integrate Entity Framework Core nuget libraries to use a SQLite database for storing the student list

2. Create a new database context class that inherits from `DbContext` and contains a `DbSet` property for the `Student` entity

3. Update the existing add endpoint to save the student data to the database

4. Update the existing get endpoint to retrieve the student data from the database

5. Update the existing update endpoint to update the student data in the database

6. Update the existing delete endpoint to delete the student data from the database

7. Ensure that all existing tests are still passing after the changes

8. Ask copilot to help you with the implementation to avoid 404 on delete endpoint

9. Ask copilot to help with commit message

10. Ask copilot to document the endpoints in markdown

## Constraints

- Do not change the existing tests, they should still pass after the changes with minimal modifications

- Do not change the existing API endpoints

## Acceptance Criteria

- A new database context class is created that inherits from `DbContext` and contains a `DbSet` property for the `Student` entity

- The existing add endpoint saves the student data to the database

- The existing get endpoint retrieves the student data from the database

- The existing update endpoint updates the student data in the database

- The existing delete endpoint deletes the student data from the database

- All existing tests are still passing after the changes

- The commit message follows the convention: `feat: implement database integration using Entity Framework Core`

## Resources

- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/providers/sqlite)
- [SQLite](https://www.sqlite.org/index.html)
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)

# Student class

```csharp
public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public int LastName { get; set; }
}
```

## API Endpoints

### Add Student

- URL: `/api/students`
- Method: `POST`
- Request Body:

```json
{
    "firstName": "John Doe",
    "lastName": 25
}
```

- Response Body:

```json
{
    "id": 1,
    "firstName": "John Doe",
    "lastName": 25
}
```

### Get Student

- URL: `/api/students/{id}`
- Method: `GET`

- Response Body:

```json
{
    "id": 1,
    "firstName": "John Doe",
    "lastName": 25
}
```

### Update Student

- URL: `/api/students/{id}`
- Method: `PUT`
- Request Body:

```json
{
    "firstName": "John Doe",
    "lastName": 25
}
```

- Response Body:

```json
{
    "id": 1,
    "firstName": "John Doe",
    "lastName": 25
}
```

### Delete Student

- URL: `/api/students/{id}`
- Method: `DELETE`
