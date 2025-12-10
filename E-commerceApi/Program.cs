using Travel.Data;
using Travel.Interfaces;
using Travel.Repository.Interfaces;
using Travel.Repository.Services;
using Travel.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Travel.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Travel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using Travel.Models;
using Travel.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Travel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY") ?? builder.Configuration["jwt:Key"];
            var emailUser = Environment.GetEnvironmentVariable("EMAIL_USER") ?? builder.Configuration["EmailSettings:Email"];
            var emailPass = Environment.GetEnvironmentVariable("EMAIL_PASSWORD") ?? builder.Configuration["EmailSettings:Password"];
            // Add DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();

            builder.Services.AddDbContext<ApplicationDbContext>(opations => opations.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            var emailSettings = new EmailSettings
            {
                SmtpServer = builder.Configuration["EmailSettings:SmtpServer"],
                Port = int.Parse(builder.Configuration["EmailSettings:Port"] ?? "587"),
                Password = emailPass,
                Email = emailUser
            };
            builder.Services.AddSingleton<EmailService>(sp =>
            new EmailService(emailSettings));

            var jwtSettings = builder.Configuration.GetSection("jwt");
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;      // read cookies
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; // save cookies (VERY IMPORTANT)
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;           // redirect to Google
            })

            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            })
            .AddGoogle(options =>
            {
                options.ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
                options.ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");
                options.CallbackPath = "/api/ExternalAuth/GoogleResponse";
                options.SaveTokens = true;
            })
            // نضيف JwtBearer كذلك / علشان الـ APIs تحمي بـ JWT بعد إصدار التوكن
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });



            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });


            builder.Services.AddScoped<LocalImageService>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            var app = builder.Build();

            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travel V1");
                    c.RoutePrefix = "docs"; // رابط الـ documentation
                });
            //}

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
