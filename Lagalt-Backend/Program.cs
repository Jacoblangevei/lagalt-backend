using Lagalt_Backend.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Lagalt_Backend.Services.Projects;
using Lagalt_Backend.Services.Messages;
using Lagalt_Backend.Services.Users;
using Lagalt_Backend.Services.Owners;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
            {
                using var client = new HttpClient();
                var keyuri = builder.Configuration["TokenSecrets:KeyURI"];
                var response = client.GetAsync(keyuri).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);
                return keys.Keys;
            },
            ValidIssuers = new List<string>
            {
                builder.Configuration["TokenSecrets:IssuerURI"]
            },
            ValidAudience = "account",
        };
    });*/

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "LagaltAPI", Version = "v1" });
    // Include XML Comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

builder.Services.AddDbContext<LagaltDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

// Add our service
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://lagalt.azurewebsites.net")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();        
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.Environment.IsDevelopment()

// TESTEST2345673

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
