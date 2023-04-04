using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Data_Access.CommentDal;
using Instagram_Clone_Backend.Data_Access.FollowerDal;
using Instagram_Clone_Backend.Data_Access.LikeDal;
using Instagram_Clone_Backend.Data_Access.PostDal;
using Instagram_Clone_Backend.Data_Access.UserDal;
using Instagram_Clone_Backend.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Instagram_Clone_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the Dependincy container.
            builder.Services.AddControllers(o =>
            {
                o.ReturnHttpNotAcceptable = true;

            }).AddXmlDataContractSerializerFormatters().AddJsonOptions((o =>
            {
                o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                o.JsonSerializerOptions.WriteIndented = true;
            }));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(); // you can add name it defaults to cookies
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<InstagramCloneContext>(op =>
                op.UseSqlServer(
                    builder.Configuration["ConnectionStrings:InstagramDB"]));
            builder.Services.AddSignalR();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddSingleton<IUserDal, UserDal>();
            builder.Services.AddSingleton<IPostDal, PostDal>();
            builder.Services.AddSingleton<ILikeDal, LikeDal>();
            builder.Services.AddSingleton<ICommentDal, CommentDal>();
            builder.Services.AddSingleton<IFollowerDal, FollowerDal>();
            var app = builder.Build();
            app.UseCors(cors =>
            {
                cors.AllowAnyOrigin();
                cors.AllowAnyHeader();
                cors.AllowAnyMethod();
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors(o =>
            {
                o.WithOrigins("https://localhost:7003");
                o.AllowAnyHeader();
                o.AllowAnyMethod();
            });
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapHub<InstagramHub>("/InstagramHub");
            app.Run();
        }
    }
}