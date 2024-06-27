namespace MinimalAPI;

// this is a crud API to create, read, update and delete a list of students
// /create - POST - to create a new student
// / - GET - to read all students
// /read - GET - to read a student by ID
// /update/{studentId} - PUT - to update a student
// /delete/{studentId} - DELETE - to delete a student
// ReSharper disable once InconsistentNaming
public static class StudentAPIs
{
    static readonly List<Student> _students = new();

    public static void MapAPI(this WebApplication app)
    {
        app.MapPost("/create",
                    async ([FromBody] Student student) =>
                    {
						_students.Add(student);
                        return Results.Ok(student);
                    });

        app.MapGet("/",
                   () => Results.Ok(_students));

        app.MapGet("/read/{studentId:int}",
                   (int studentId) =>
                   {
                       var student = _students.First(s => s.Id == studentId);
                       return Results.Ok(student);
                   });

        app.MapPut("/update/{studentId:int}",
                   (int                studentId,
                    [FromBody] Student student) =>
                   {
                       var existingStudent = _students.First(e => e.Id == studentId);

                       existingStudent.FirstName = student.FirstName;
                       existingStudent.LastName  = student.LastName;

                       return Results.Ok(existingStudent);
                   });

        app.MapDelete("/delete/{studentId:int}",
                      (int studentId) =>
                      {
                          var existingStudent = _students.First(s => s.Id == studentId);
                          _students.Remove(existingStudent);
                          return Results.Ok();
                      });
    }
}
