using Instagram_Clone_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram_Clone_Backend.Contexts
{
    public class InstagramCloneContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public InstagramCloneContext(DbContextOptions<InstagramCloneContext> options)
        {
        }

        public InstagramCloneContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Instagram_Clone;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().
                HasOne(c => c.UserProfile).
                WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserProfileId).
                OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.UserProfile)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Follower>()
                .HasOne(l => l.UserProfile)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Follower>()
                .HasOne(f => f.FollowerProfile).WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Follower>()
                .HasOne(f => f.UserProfile)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UserProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}

