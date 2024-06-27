# Student API

This API provides CRUD operations for managing students.

## Goal

Currently the API is using an a persistent database with Entity Framework Core.

## Tasks

### [01] Fix Bugs in existing API

1. Use copilot to fix bug in the `PUT` endpoint and add corresponding tests.
2. Use copilot to fix bug in the `DELETE` endpoint and add corresponding tests.

### [02] Search endpoint and Linq Query Generation

1. Create a new endpoint to search for students by term on either first name or last name.
2. Use comment prompt get unique last names of students
3. Use comment prompt to non duplicated students by first name and last name
4. Use comment prompt to get students born after 2000

    ```csharp
    // create a new endpoint to search for students by term on either first name or last name
   app.MapGet("/search/{term}",
      async (string term, 
            [FromServices] StudentContext context) =>
        {
            // ## copilot comment prompt ##

           // search for student by term, on either first name or last name
           var students = await context.Students
                                       .Where(s => s.FirstName.Contains(term) ||
                                                   s.LastName.Contains(term))
                                       .ToListAsync();
           
           // get all students that have lastName "A" without duplicates
           var studentsWithLastNameA = context.Students
                                              .Where(s => s.LastName == "A")
                                              .Distinct()
                                              .ToList();

           // get all unique last names
           var uniqueLastNames = context.Students.Select(s => s.LastName)
                                        .Distinct()
                                        .ToList();

           // get non duplicate students by first name, last name and birth date
           var nonDuplicateStudents = context.Students
                                             .GroupBy(s => new {s.FirstName, s.LastName, s.BirthDate})
                                             .Select(g => g.First())
                                             .ToList();

           // get all students born after 2000
           var studentsBornAfter2000 = context.Students
                                              .Where(s => s.BirthDate.Year > 2000)
                                              .ToList();
           return Results.Ok(students);
       });
    ```

   Copilot will generate linq queries for the new search endpoint using the comment prompt.

### [03] Use copilot to generate tests for the new search endpoint using the comment prompt

   ```csharp
    // ## copilot comment prompt ##
   
    // add test for the search endpoint
    [Fact]
    public async Task Search_EndpointReturnsSuccess()
    {
        // arrange
        var student1 = new {Id = 1, FirstName = "John", LastName = "Doe"};
        var student2 = new {Id = 2, FirstName = "Jane", LastName = "Doe"};

        await _client.PostAsync("/create", new StringContent(JsonSerializer.Serialize(student1), Encoding.UTF8, "application/json"));
        await _client.PostAsync("/create", new StringContent(JsonSerializer.Serialize(student2), Encoding.UTF8, "application/json"));

        // Act
        var response = await _client.GetAsync("/search/Jane");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var responseString = await response.Content.ReadAsStringAsync();
        var students = JsonSerializer.Deserialize<List<Student>>(responseString, _jsonSerializerOptions);

        Assert.NotNull(students);
        Assert.DoesNotContain(students, s => s.Id == 1);
        Assert.Contains(students, s => s.Id == 2);
    }
```

The generated test respect test pattern from previous tests

### [04] Use copilot to fix bug in the `Age` property and add corresponding tests

Ensure that the tests are passing with 100% code coverage.

### [05] Use copilot to generate tests for the API defined in swagger.json file

1. Add the swagger.json file to the project (already added)
2. Use copilot chat and reference the swagger.json file and StudentAPITs.cs file
3. Prompt copilot to generate the APIs defined in swagger.json file like in the image below

    ![Chat Swagger API](img/chat-swagger.png "Chat Swagger API")
