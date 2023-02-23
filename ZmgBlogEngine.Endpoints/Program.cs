using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Filters;
using ZmgBlogEngine.DataAccess.Models;
using ZmgBlogEngine.DataAccess.Repositories;
using ZmgBlogEngine.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddTransient<IPublicService, PublicService>()
    .AddTransient<IWriterService, WriterService>()
    .AddTransient<IEditorService, EditorService>()
    .AddTransient<ILoginService, LoginService>()
    .AddTransient<IPostRepository, PostRepository>()
    .AddTransient<ICommentRepository, CommentRepository>()
    .AddTransient<IUserRepository, UserRepository>()
    .AddTransient<ZmgDbContext, ZmgDbContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Register the Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();

    c.SwaggerDoc("v2", new OpenApiInfo { Title = "ZmgBlogEngine", Version = "v1" });
});


builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "ZmgBlogEngine");
});

app.Run();
