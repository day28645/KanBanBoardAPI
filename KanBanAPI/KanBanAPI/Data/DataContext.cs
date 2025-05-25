using KanBanAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KanBanAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<KanbanTask> KanbanTasks { get; set; }
        public DbSet<EditBoard> EditBoards { get; set; }
        public DbSet<EditTask> EditTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Logins)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.Id_Card);

            modelBuilder.Entity<User>()
                .HasMany(e => e.createBoards)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.Id_Card);

            modelBuilder.Entity<User>()
                .HasMany(e => e.createTasks)
                .WithOne(e => e.Users)
                .HasForeignKey(e => e.Id_Card);
                
            modelBuilder.Entity<EditBoard>()
                .HasKey(e => e.editId);
            modelBuilder.Entity<EditBoard>()
                .HasOne(e => e.Users)
                .WithMany(e => e.EditBoards)
                .HasForeignKey(e => e.Id_Card)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EditBoard>()
                .HasOne(e => e.Boards)
                .WithMany(e => e.EditBoards)
                .HasForeignKey(e => e.Board_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EditTask>()
                .HasKey(e => e.editTaskId);
            modelBuilder.Entity<EditTask>()
                .HasOne(e => e.Users)
                .WithMany(e => e.EditTasks)
                .HasForeignKey(e => e.Id_Card)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EditTask>()
                .HasOne(e => e.KanbanTasks)
                .WithMany(e => e.EditTasks)
                .HasForeignKey(e => e.Task_Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
