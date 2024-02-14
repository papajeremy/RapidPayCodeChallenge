using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RapidPayApi.Authentication;
using RapidPayApi.Data;
using RapidPayApi.Services;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var dbConnectionString = builder.Configuration.GetConnectionString("RapidPaySqlConnectionString");
builder.Services.AddDbContext<IdentityDbContext>( 
    options => options.UseSqlServer( dbConnectionString ) );
builder.Services.AddDbContext<RapidPayDbContext>(
    options => options.UseSqlServer( dbConnectionString ) );
builder.Services.AddIdentity<RapidPayUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication( options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
} ).AddJwtBearer( options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration [ "JWT:ValidAudience" ],
        ValidIssuer = builder.Configuration [ "JWT:ValidIssuer" ],
        IssuerSigningKey = new SymmetricSecurityKey( Encoding.UTF8
        .GetBytes( builder.Configuration [ "JWT:Secret" ] ) )
    };
} );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( c => {
    c.SwaggerDoc( "v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    } );
    c.AddSecurityDefinition( "Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    } );
    c.AddSecurityRequirement( new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    } );
} );
builder.Services.AddSingleton<PaymentFeeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
