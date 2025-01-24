# Scenario

You are a developer tasked with designing an application using the provided `swagger.json` file as the starting point.

The project is a RESTful API that provides CRUD operations for a list of students.

## Step-by-Step Process

### Step 1: Review the `swagger.json` File

1. Open the `swagger.json` file located in this directory.
2. Review the API endpoints, request parameters, and response schemas defined in the file.

### Step 2: Generate API Endpoints

1. Use GitHub Copilot to generate the API endpoints defined in the `swagger.json` file.
2. Ensure that the generated endpoints match the specifications in the `swagger.json` file.

### Step 3: Implement the API Endpoints

1. Create a new Python project using Flask or FastAPI.
2. Implement the API endpoints using the generated code from GitHub Copilot.
3. Ensure that the endpoints handle the request parameters and return the appropriate response schemas.

### Step 4: Use In-Memory Storage

1. Implement in-memory storage to store the student data.
2. Create a simple data structure (e.g., a list or dictionary) to hold the student data.

### Step 5: Update Endpoints to Use In-Memory Storage

1. Update the existing add endpoint to save the student data to the in-memory storage.
2. Update the existing get endpoint to retrieve the student data from the in-memory storage.
3. Update the existing update endpoint to update the student data in the in-memory storage.
4. Update the existing delete endpoint to delete the student data from the in-memory storage.

### Step 6: Test the API Endpoints

1. Write unit tests for each API endpoint to ensure they work as expected.
2. Use GitHub Copilot to help generate the tests.
3. Ensure that all tests are passing.

### Step 7: Document the API Endpoints

1. Use GitHub Copilot to generate documentation for the API endpoints.
2. Ensure that the documentation includes details about the request parameters and response schemas.

### Acceptance Criteria

- All API endpoints defined in the `swagger.json` file are implemented.
- The API endpoints use in-memory storage for simplicity.
- Unit tests are written and passing for all API endpoints.
- Documentation for the API endpoints is generated and accurate.

## Resources

- [Flask](https://flask.palletsprojects.com/)
- [FastAPI](https://fastapi.tiangolo.com/)
