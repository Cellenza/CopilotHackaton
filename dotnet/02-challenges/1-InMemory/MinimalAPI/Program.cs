#region Setup

    using MinimalAPI;

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpClient();
    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

#endregion

#region Run

app.MapAPI();
app.Run();

public class Student
{
    public int    Id        { get; set; }
    public string FirstName { get; set; }
    public string LastName  { get; set; }
}

// Needed to be able to access this type from the MinimalAPI.Tests project.
namespace MinimalAPI
{
    public partial class Program;
}

#endregion