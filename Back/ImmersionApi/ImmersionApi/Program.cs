using ImmersionApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using WebAPI.Controllers.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<HardSkillFakeDB>();
builder.Services.AddSingleton<DiplomaFakeDB>();
builder.Services.AddSingleton<UploadService>();
builder.Services.AddSingleton<UserFakeDB>();
builder.Services.AddSingleton<JobFakeDB>();
builder.Services.AddSingleton<SoftSkillFakeDb>();
builder.Services.AddSingleton<UserProfilFakeDB>();
builder.Services.AddSingleton<RegularProfilFakeDB>();

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("allConnections", builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


// Configuration de l'Authentification via JWT
builder.Services.AddAuthentication(options =>
{
    // Les options du sh�ma de l'authentification en elle m�me. Ici ne rien mettre n'aurait rien chang�, mais c'est pour montrer qu'il est configurable
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // Les options du token a proprement parl� 
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Utilisation d'une cl� crypt�e pour la s�curit� du token
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])), // Assignation de la valeur de la cl�
        ValidateLifetime = true, // V�rification du temps d'expiration du token
        ValidateAudience = true, // V�rification de l'audience du token
        ValidAudience = builder.Configuration["JWT:ValidAudience"], // Audience valid�e pour ce token
        ValidateIssuer = true, // V�rification du donneur du token 
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"], // Donneur de token accept� pour ce token
        ClockSkew = TimeSpan.Zero // D�calage possible de l'expiration du token
    };
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

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
