using ProjPract2.Data;
using ProjPract2.Interface;
using ProjPract2.Services;

var builder = WebApplication.CreateBuilder(args);

// ? Add controllers
builder.Services.AddControllers();

// ? Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ? Dependency Injection registrations
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRepository, StudentRepository>();
builder.Services.AddScoped<IService, StudentServices>();

var app = builder.Build();

// ? Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
