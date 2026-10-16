using AcademyApp.data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var conn_srt = builder.Configuration.GetConnectionString("DefaultConnection");
var student_repo = new Studentrepos(conn_srt);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.MapGet("/students/all", () =>
{
    var students = student_repo.FindAllStudents();
    return Results.Ok(students);
});

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
