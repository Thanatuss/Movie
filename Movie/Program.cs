using Microsoft.EntityFrameworkCore;
using Movie.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // برای OpenAPI یا 
builder.Services.AddSwaggerGen(); // برای Swagger UI
builder.Services.AddSwaggerGen();
// Add DbContext to the container
builder.Services.AddDbContext<ProgramDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger");
        return Task.CompletedTask;
    });


}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
                                                                                            
app.Run();

