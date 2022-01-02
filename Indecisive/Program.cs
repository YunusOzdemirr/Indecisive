using Indecisive.Filters;
using Indecisive.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Services.AutoMapper.Profiles;
using Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using Data.Concrete.EntityFramework.Context;
using System.Security.Claims;
using Shared.Utilities.Security.Encryption;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.HttpOverrides;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Configure the HTTP request pipeline.
builder.Services.AddAutoMapper(typeof(CategoryProfile), typeof(CompanyProfile), typeof(ProductProfile), typeof(PremiumProductProfile));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
          {
              options.SuppressModelStateInvalidFilter = true;
          });
builder.Services.LoadMyServices();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<JsonExceptionFilter>();
    // var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedLoUser().Build();
    //options.Filters.Add(new AuthorizeFilter(policy));
}).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });
builder.Services.AddSwaggerGen(c =>
           {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Indecisive.Api", Version = "v1" });
               c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
               {
                   Description = @"JWT Authorization header using the Bearer scheme.
                     Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                   Name = "Authorization",
                   In = ParameterLocation.Header,
                   Type = SecuritySchemeType.ApiKey,
                   Scheme = "Bearer"
               });
               c.AddSecurityRequirement(new OpenApiSecurityRequirement()
               {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            },
                            Scheme="oauth2",
                            Name="Bearer",
                            In=ParameterLocation.Header,
                        },
                        new List<string>()
                    }
               });
           });
builder.Services.AddLogging();
// var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<Shared.Utilities.Security.Jwt.TokenOptions>();

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options =>
//                {
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuer = true,
//                        ValidateAudience = true,
//                        ValidateLifetime = true,
//                        ValidIssuer = tokenOptions.Issuer,
//                        ValidAudience = tokenOptions.Audience,
//                        ValidateIssuerSigningKey = true,
//                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
//                    };
//                });
//Authorize Role
//builder.Services.AddIdentityCore<IdentityUser>()
//               .AddEntityFrameworkStores<IndecisiveContext>()
//              .AddDefaultTokenProviders();

//builder.Services.AddAuthorization(options =>
//options.AddPolicy("Role",
//   policy => policy.RequireClaim(claimType: ClaimTypes.Role, "Admin", "NormalUser")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indecisive.API v1"));
app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


