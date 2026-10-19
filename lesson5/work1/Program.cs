using AcademyApp.data;
using AcademyApp.model;
using Microsoft.AspNetCore.Mvc.RazorPages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var conn_srt = builder.Configuration.GetConnectionString("DefaultConnection");
var student_repo = new Studentrepos(conn_srt);
builder.Services.AddSingleton(new Studentrepos(conn_srt));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.MapGet("/student/all", (Studentrepos student_repo) =>
{
    var student = student_repo.FindAllStudents();
    return Results.Ok(student);
});

app.MapGet("/student/{id:int}", (int id) =>
{
    var student = student_repo.FindStudentBeId(id);
    return Results.Ok(student);
});

app.MapPost("/student/", (Studentrepos stdent_repo, string first_name, string last_name, int age, int group_id) =>
{
    student_repo.AddStudent(first_name, last_name, age, group_id);

    return Results.Ok();
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
