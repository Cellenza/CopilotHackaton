using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPI;

// this is a crud API to create, read, update and delete a list of students
// /create - POST - to create a new student
// /read - GET - to read all students
// /update/{studentId} - PUT - to update a student
// /delete/{studentId} - DELETE - to delete a student
// ReSharper disable once InconsistentNaming
public static class StudentAPIs
{
    public static void MapAPI(this WebApplication app)
    {
        app.MapGet("/",
                   async ([FromServices] StudentContext dbContext) =>
                   {
                       var students = await dbContext.Students.ToListAsync();
                       return Results.Ok(students);
                   });

        app.MapGet("/read/{studentId:int}",
                   async (int studentId, [FromServices] StudentContext context) =>
                   {
                       var student = await context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
                       if (student == null)
                       {
                           return Results.NotFound($"No student found with ID {studentId}");
                       }

                       return Results.Ok(student);
                   });

		app.MapPost("/create",
			async ([FromServices] StudentContext dbContext,
				   [FromBody] Student student) =>
			{
				var existingStudent = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == student.Id);
				if (existingStudent != null)
				{
					return Results.Conflict($"Student with ID {student.Id} already exists");
				}

				dbContext.Students.Add(student);
				await dbContext.SaveChangesAsync();

				return Results.Ok(student);
			});

		app.MapPut("/update/{studentId:int}",
                   async (int                           studentId,
                          [FromBody]     Student        student,
                          [FromServices] StudentContext context) =>
                   {
                       var existingStudent = await context.Students.FirstOrDefaultAsync(e => e.Id == studentId);

                       if (existingStudent == null)
                       {
                           return Results.NotFound($"No student found with ID {studentId}");
                       }

                       existingStudent.FirstName = student.FirstName;
                       existingStudent.LastName  = student.LastName;

                       await context.SaveChangesAsync();
                       return Results.Ok(existingStudent);
                   });

        app.MapDelete("/delete/{studentId:int}",
                      async (int                           studentId,
                             [FromServices] StudentContext context) =>
                      {
                          var existingStudent = await context.Students.FirstOrDefaultAsync(s => s.Id == studentId);
                          if (existingStudent == null)
                          {
                              return Results.NotFound($"No student found with ID {studentId}");
                          }

                          context.Students.Remove(existingStudent);
                          await context.SaveChangesAsync();
                          return Results.Ok();
                      });
    }
}
