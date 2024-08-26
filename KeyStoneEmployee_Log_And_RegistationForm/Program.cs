using KeyStoneEmployee_Log_And_RegistationForm_BusinessObject.InterFace;
using KeyStoneEmployee_Log_And_RegistationForm_DataBaseLogic.Data;
using KeyStoneEmployee_Log_And_RegistationForm_RepositaryLayer;
using KeyStoneEmployee_Log_And_RegistationForm_ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepositary, UserRepositary>();
builder.Services.AddScoped<IUserService, userService>();
builder.Services.AddScoped<IKeystoneConfigurationFactory, KeystoneConfigurationFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
