using ImmersionApi.Data;
using WebAPI.Controllers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<HardSkillFakeDB>();
builder.Services.AddSingleton<DiplomaFakeDB>();
builder.Services.AddSingleton<UploadService>();
builder.Services.AddSingleton<UserFakeDB>();
builder.Services.AddSingleton<JobFakeDB>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("allConnections", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


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


app.UseCors("allConnections");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
