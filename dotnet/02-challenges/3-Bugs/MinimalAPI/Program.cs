#region Setup

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Microsoft.EntityFrameworkCore.Storage;

    using MinimalAPI;

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddHttpClient();
    builder.Services.AddDbContext<StudentContext>();
    
    var app = builder.Build();
    app.UseSwagger();
    app.UseSwaggerUI();

#endregion

    app.MapAPI();

#region Run

    // run ef migrations fro scoped services
    using var scope     = app.Services.CreateScope();
    using var dbContext = scope.ServiceProvider.GetRequiredService<StudentContext>();
    if (!dbContext.Database.GetService<IRelationalDatabaseCreator>()
                  .HasTables())
    {
        dbContext.Database.GetService<IRelationalDatabaseCreator>()
                 .CreateTables();
    }

    app.Run();

#region Models

    public class Student
    {
        public int    Id        { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
    }

    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options) { options.UseSqlite($"Data Source={Path.Join(AppContext.BaseDirectory, "students.db")}"); }

        public virtual DbSet<Student> Students { get; set; }
    }

    // Needed to be able to access this type from the MinimalAPI.Tests project.
    namespace MinimalAPI
    {
        public partial class Program;
    }
#endregion

#endregion
