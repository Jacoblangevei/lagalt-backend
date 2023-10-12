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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "LagaltAPI", Version = "v1" });
    // Include XML Comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

//                              Versjon 1

// Add Authentication 
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

//                              Versjon 2

//Keycloak
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            IssuerSigningKeyResolver = async (token, securityToken, kid, parameters) =>
//            {
//                // Uses IHttpClientFactory to get an instance of HttpClient
//                var clientFactory = builder.Services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();
//                var client = clientFactory.CreateClient();
//                var keyuri = builder.Configuration["TokenSecrets:KeyURI"];

//                try
//                {
//                    var response = await client.GetAsync(keyuri);
//                    response.EnsureSuccessStatusCode(); // Throws an exception if the response is not successful.
//                    var responseString = await response.Content.ReadAsStringAsync();
//                    var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);
//                    return keys.Keys;
//                }
//                catch (HttpRequestException e)
//                {
//                    // Log and handle exception
//                    throw new SecurityTokenException("Cannot retrieve keys", e);
//                }
//            },
//            ValidIssuers = new List<string>
//            {
//                builder.Configuration["TokenSecrets:IssuerURI"]
//            },
//            ValidAudience = "account",
//        };
//    });


builder.Services.AddDbContext<LagaltDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

// Add our service
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IProjectTypeService, ProjectTypeService>();
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
