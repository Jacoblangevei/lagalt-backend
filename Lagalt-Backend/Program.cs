using Lagalt_Backend.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Lagalt_Backend.Services.Projects;
using Lagalt_Backend.Services.Messages;
using Lagalt_Backend.Services.Users;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Lagalt_Backend.Services.ProjectRequests;
using Lagalt_Backend.Services.Projects.Updates;
using Lagalt_Backend.Services.Projects.ProjectStatuses;
using Lagalt_Backend.Services.Projects.MilestoneStatuses;
using Lagalt_Backend.Services.Projects.Messages;
using Lagalt_Backend.Services.Projects.Milestones;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;


var builder = WebApplication.CreateBuilder(args);

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


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            
            IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
            {
                using var client = new HttpClient();
                var keyuri = "https://lemur-10.cloud-iam.com/auth/realms/lagaltfrontend/protocol/openid-connect/certs"; // .../openid/certs from sample/notes
                var response = client.GetAsync(keyuri).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);
                return keys.Keys;
            },
            ValidIssuer = "https://lemur-10.cloud-iam.com/auth/realms/lagaltfrontend",
            //{
            //     // url to kc realm
            //    //https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-7.0&tabs=windows
            //    //https://gitlab.com/NicholasLennox/securityaugust2023/-/blob/main/SecurityClass/Program.cs?ref_type=heads
            //}
        };
    });


builder.Services.AddDbContext<LagaltDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

// Add our service
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectTypeService, ProjectTypeService>();
builder.Services.AddScoped<IProjectRequestService,  ProjectRequestService>();
builder.Services.AddScoped<IUpdateService, UpdateService>();
builder.Services.AddScoped<IProjectStatusService, ProjectStatusService>();
builder.Services.AddScoped<IMilestoneService, MilestoneService>();
builder.Services.AddScoped<IMilestoneStatusService, MilestoneStatusService>();
builder.Services.AddScoped<IMessageProjectService, MessageProjectService>();
builder.Services.AddScoped<Lagalt_Backend.Services.Projects.Resources.IResourceService, Lagalt_Backend.Services.Projects.Resources.ResourceService>();

// Add automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://best-lagalt-project-git-main-ken-pixel-source.vercel.app") // Update with your Vercel URL
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });

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
app.Environment.IsDevelopment();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
