using System.Net;
using System.Text;
using System.Text.Json;

using MinimalAPI.Tests.Helpers;

namespace MinimalAPI.Tests;

public class StudentTests(TestWebApplicationFactory<Program> factory) : IClassFixture<TestWebApplicationFactory<Program>>
{
    readonly HttpClient            _client                = factory.CreateClient();
    readonly JsonSerializerOptions _jsonSerializerOptions = new() {PropertyNameCaseInsensitive = true,};

#region Create

    [Fact]
    public async Task CreateStudent_ReturnsCreatedStudent()
    {
        // Arrange
        var student = new Student {FirstName = "John", LastName = "Doe",};
        var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/create", content);

        // Assert
        response.EnsureSuccessStatusCode();

        var returnedStudent = JsonSerializer.Deserialize<Student>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
        Assert.Equal(student.FirstName, returnedStudent?.FirstName);
        Assert.Equal(student.LastName,  returnedStudent?.LastName);
    }

    [Fact]
    public async Task CreateStudent_ReturnsBadRequest_WhenStudentIsNull()
    {
        // Arrange
        StringContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/create", content);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateStudent_ReturnsConflict_WhenIdAlreadyExists()
    {
        // Arrange
        var student = new Student {Id = 1, FirstName = "John", LastName = "Doe"};
        var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
        await _client.PostAsync("/create", content); // Create a student with Id 1

        var duplicateStudent = new Student {Id = 1, FirstName = "Jane", LastName = "Doe"};
        content = new(JsonSerializer.Serialize(duplicateStudent), Encoding.UTF8, "application/json"); // Create another student with the same Id

        // Act
        var response = await _client.PostAsync("/create", content);

        // Assert
        Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
    }

#endregion

#region Update

    [Fact]
    public async Task UpdateStudent_ReturnsUpdatedStudent()
    {
        // Arrange
        var student = new Student {FirstName = "John", LastName = "Doe",};
        var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

        var createdResult  = await _client.PostAsync("/create", content);
        var createdStudent = JsonSerializer.Deserialize<Student>(await createdResult.Content.ReadAsStringAsync(), _jsonSerializerOptions);

        // Act
        student.FirstName = "Jane";
        content           = new(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
        var response = await _client.PutAsync($"/update/{createdStudent?.Id}", content);

        // Assert
        response.EnsureSuccessStatusCode();
        var returnedStudent = JsonSerializer.Deserialize<Student>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
        Assert.Equal(student.FirstName, returnedStudent?.FirstName);
        Assert.Equal(student.LastName,  returnedStudent?.LastName);
    }

    [Fact]
    public async Task UpdateStudent_ReturnsNotFound_WhenStudentDoesNotExist()
    {
        var student = new Student {Id = 999, FirstName = "John", LastName = "Doe"};
        var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("/update/999", content);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

#endregion

#region Delete

    [Fact]
    public async Task DeleteStudent_ReturnsOk_WhenStudentExists()
    {
        // Arrange
        var student = new Student {Id = 1, FirstName = "John", LastName = "Doe"};
        var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");
        await _client.PostAsync("/create", content);

        // Act
        var response = await _client.DeleteAsync("/delete/1");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task DeleteStudent_ReturnsNotFound_WhenStudentDoesNotExist()
    {
        var response = await _client.DeleteAsync("/delete/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

#endregion

#region Read

    [Fact]
    public async Task Reads_EndpointReturnsSuccessAndCorrectContentType()
    {
        // arrange
        var student1 = new {Id = 1, FirstName = "John", LastName = "Doe"};
        var student2 = new {Id = 2, FirstName = "Jane", LastName = "Doe"};

        var student1Json = JsonSerializer.Serialize(student1);
        var student2Json = JsonSerializer.Serialize(student2);
        await _client.PostAsync("/create", new StringContent(student1Json, Encoding.UTF8, "application/json"));
        await _client.PostAsync("/create", new StringContent(student2Json, Encoding.UTF8, "application/json"));

        // Act
        var response = await _client.GetAsync("/");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var responseString = await response.Content.ReadAsStringAsync();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        var students = JsonSerializer.Deserialize<List<Student>>(responseString, _jsonSerializerOptions);

        Assert.NotNull(students);
        Assert.Contains(students, s => s.Id == 1);
        Assert.Contains(students, s => s.Id == 2);
    }

    [Fact]
    public async Task Read_EndpointReturnsSuccessAndCorrectContentType()
    {
        // arrange
        var student = new {Id = 1, FirstName = "John", LastName = "Doe"};
        var json    = JsonSerializer.Serialize(student);
        var data    = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync("/create", data);

        // Act
        var response = await _client.GetAsync("/read/1");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var responseString  = await response.Content.ReadAsStringAsync();
        var studentResponse = JsonSerializer.Deserialize<Student>(responseString, _jsonSerializerOptions);

        Assert.NotNull(studentResponse);
        Assert.Equal(1,      studentResponse.Id);
        Assert.Equal("John", studentResponse.FirstName);
        Assert.Equal("Doe",  studentResponse.LastName);
    }

    [Fact]
    public async Task GetStudent_ReturnsNotFound_WhenIdDoesNotExist()
    {
        // Arrange
        var nonExistentStudentId = 999; // Assuming this Id does not exist in the database

        // Act
        var response = await _client.GetAsync($"/read/{nonExistentStudentId}");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

#endregion
}
