using ManagementTask.Business.TokenService;
using ManagementTask.DataAccess;
using ManagementTask.Domain.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Inyeccion de dependencias
builder.Services.AddDbContext<TaskContext>(options => options.UseSqlServer("Server = KAKASHI\\SQLEXPRESS; Database = Task;User Id=sa; Password=Kakashi2403*"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
IServiceCollection serviceCollection = builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITokenService, TokenService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
