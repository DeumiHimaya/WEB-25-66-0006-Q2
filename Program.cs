using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add DbContext for your SQL Server database
builder.Services.AddDbContext<StudentManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentManagementConnection")
    ?? throw new InvalidOperationException("Connection string 'StudentManagementConnection' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map Razor Pages
app.MapRazorPages();

app.Run();
