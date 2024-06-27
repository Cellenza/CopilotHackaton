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
        var student = new Student {Id = 1, FirstName = "John", LastName = "Doe"};
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
    public async Task Create_EndpointReturnsSuccessAndCorrectContentType()
    {
        // Arrange
        var student = new {Id = 1, FirstName = "John", LastName = "Doe"};
        var json    = JsonSerializer.Serialize(student);
        var data    = new StringContent(json, Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/create", data);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }

#endregion

#region Update

    [Fact]
    public async Task UpdateStudent_ReturnsUpdatedStudent()
    {
        var student = new Student {Id = 1, FirstName = "John", LastName = "Doe"};
        var content = new StringContent(JsonSerializer.Serialize(student), Encoding.UTF8, "application/json");

        var response = await _client.PutAsync("/update/1", content);

        response.EnsureSuccessStatusCode();
        var returnedStudent = JsonSerializer.Deserialize<Student>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
        Assert.Equal(student.FirstName, returnedStudent?.FirstName);
        Assert.Equal(student.LastName,  returnedStudent?.LastName);
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

#endregion

#region Read

    [Fact]
    public async Task Reads_EndpointReturnsSuccessAndCorrectContentType()
    {
        // arrange
        var student = new {Id = 1, FirstName = "John", LastName = "Doe"};
        var json    = JsonSerializer.Serialize(student);
        var data    = new StringContent(json, Encoding.UTF8, "application/json");
        await _client.PostAsync("/create", data);

        // Act
        var response = await _client.GetAsync("/");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var responseString = await response.Content.ReadAsStringAsync();
        var students       = JsonSerializer.Deserialize<List<Student>>(responseString, _jsonSerializerOptions);
    }

    [Fact]
    public async Task Read_EndpointReturnsSuccessAndCorrectContentType()
    {
        // arrange
        var student = new {Id = 1, FirstName = "John", LastName = "Doe"};
        var json    = JsonSerializer.Serialize(student);
        await _client.PostAsync("/create", new StringContent(json, Encoding.UTF8, "application/json"));

        // Act
        var response = await _client.GetAsync("/read/1");

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299

        var responseString  = await response.Content.ReadAsStringAsync();
        var studentResponse = JsonSerializer.Deserialize<Student>(responseString, _jsonSerializerOptions);

        Assert.NotNull(studentResponse);
        Assert.Equal("John", student.FirstName);
        Assert.Equal("Doe",  student.LastName);
    }

#endregion
}
