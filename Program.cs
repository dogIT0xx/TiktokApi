﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TiktokApi.Migrations;
using TiktokApi.Entities;
using TiktokApi.Services.MailService;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CloudinaryDotNet;
using Microsoft.AspNetCore.DataProtection;
using TiktokApi.Repositories;

namespace TiktokApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("TiktokContextConnection");
                options.UseSqlServer(connectionString);
            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // User
                options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
                // Password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // SignIn
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });
            builder.Services
                .AddIdentityApiEndpoints<User>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var jwtConfigs = builder.Configuration.GetSection("Jwt");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtConfigs["Issuer"],
                        ValidAudience = jwtConfigs["ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtConfigs["IssuerSigningKey"]!)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true
                    };
                });
            builder.Services.AddAuthorization();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Config Cloudinary
            var cloudinarySetting = builder.Configuration.GetSection("Cloudinary");
            var account = new Account
            {
                Cloud = cloudinarySetting.GetValue<string>("CloudName"),
                ApiKey = cloudinarySetting.GetValue<string>("ApiKey"),
                ApiSecret = cloudinarySetting.GetValue<string>("ApiSecret"),
            };
            builder.Services.AddSingleton(new Cloudinary(account));
            #endregion

            #region Config MailSender
            builder.Services.AddOptions();  // Kích hoạt Options, tự đọng tim cấu hình 
            var mailSetting = builder.Configuration.GetSection("MailSetting");  // đọc config
            builder.Services.Configure<MailSetting>(mailSetting); // map mailSetting vào MailSetting class
            builder.Services.AddTransient<IEmailSender, EmailSender>();
            #endregion

            #region Inject repositories
            builder.Services.AddTransient<IVideoRepository, VideoRepository>();
            #endregion

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            // app.MapIdentityApi<User>();
            app.Run();
        }
    }
}
