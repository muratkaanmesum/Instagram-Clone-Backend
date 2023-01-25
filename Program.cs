using Instagram_Clone_Backend.Contexts;
using Instagram_Clone_Backend.Data_Access.CommentDal;
using Instagram_Clone_Backend.Data_Access.PostDal;
using Instagram_Clone_Backend.Data_Access.UserDal;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<InstagramCloneContext>(op =>
                op.UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Instagram_Clone;Integrated Security=True;"));
            builder.Services.AddSingleton<IUserDal, UserDal>();
            builder.Services.AddSingleton<IPostDal, PostDal>();
            builder.Services.AddSingleton<ICommentDal, CommentDal>();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}