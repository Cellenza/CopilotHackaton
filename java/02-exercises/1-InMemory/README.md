# Spring Boot 3 + OpenAPI 3.0

## Requirements

Install Java 21
Install Maven 3.9.6

DONT FORGET TO ADD YOUR ENVIRONMENT VARIABLE (JAVA_HOME, MAVEN_HOME)

## Launch Project

mvn compile    
mvn spring-boot:run

## Swagger

Navigate to: <http://localhost:42069/swagger-ui/index.html>

# Scenario

You are a developer working on an existing legacy project.

The project is a RESTful API that provides CRUD operations for a list of students.

The API is built using Spring Boot and uses in-memory storage to store the student data.

The project have tests for the API endpoints. All tests are passing.

You have been tasked with changing the in-memory storage to use a persistent storage mechanism.

## Tasks

1. Integrate H2 Database with Hibernate libraries for storing the student list

2. Update the existing add endpoint to save the student data to the database

3. Update the existing get endpoint to retrieve the student data from the database

4. Update the existing update endpoint to update the student data in the database

5. Update the existing delete endpoint to delete the student data from the database

6. Ensure that all existing tests are still passing after the changes

8. Ask copilot to help with commit message

9. Ask copilot to document the API endpoints in the source code

## Constraints

- Do not change the existing tests, they should still pass after the changes with minimal modifications

- Do not change the existing API endpoints

## Acceptance Criteria

- The existing add endpoint saves the student data to the database

- The existing get endpoint retrieves the student data from the database

- The existing update endpoint updates the student data in the database

- The existing delete endpoint deletes the student data from the database

- All existing tests are still passing after the changes

- The commit message follows the convention: `feat: implement database integration using Hibernate`

## Resources

- [Hibernate](https://hibernate.org/)
- [H2 Database](https://www.h2database.com/html/main.html)
- [Spring Boot](https://spring.io/projects/spring-boot)
- [Maven Repository](https://mvnrepository.com/)

# Student class

```
public class Student
{
  private long id;
  private String firstName;
  private String lastName;
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
