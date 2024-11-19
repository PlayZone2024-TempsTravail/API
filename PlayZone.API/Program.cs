using Npgsql;
using PlayZone.BLL.Interfaces.User_Related;
using PlayZone.BLL.Services.User_Related;
using PlayZone.DAL.Interfaces.User_Related;
using PlayZone.DAL.Repositories.User_Related;

var builder = WebApplication.CreateBuilder(args);

// Injection de la connection DB
builder.Services.AddTransient<NpgsqlConnection>(service =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

// Injection des Services de la BLL
builder.Services.AddScoped<IUserService, UserService>();

// Injection des Services de la DAL
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
