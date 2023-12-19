using Microsoft.EntityFrameworkCore;
using Wander_wisdom.Interface;
using Wander_wisdom.Models;
using Wander_wisdom.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<WanderWisdomContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("majorCon")));
builder.Services.AddScoped<IUserDetails, UserDetailsRepo>();
builder.Services.AddScoped<IPostDetails, PostDetailsRepo>();
//jwt
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
    // err -String reference not set to an instance of a String. (Parameter 's')'


});

//cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();

                      });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigin");//cors
app.UseAuthentication(); // jwt
app.UseAuthorization();

app.MapControllers();

app.Run();
