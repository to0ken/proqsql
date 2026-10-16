
using AcademyApp.data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

string conn_srt = "Data Source=COMP7A2\\SQLEXPRESS;" +
                "Initial Catalog=academyCollegh;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True";
var student_repo = new Studentrepos(conn_srt);
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/students/all", () =>
{
    var students = student_repo.FindAllStudents();
    return Results.Ok(student_repo);
});


app.Run();
