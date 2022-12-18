using Microsoft.EntityFrameworkCore;
using MsBot.Domain;
using MsBot.Domain.Msg;

namespace MsBot.Implementation.MySql
{
    public class RepositoryContext : DbContext, IRepositoryContext
    {
        private readonly string _connectionString;

        public RepositoryContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Tables

        public virtual DbSet<MsgAggregateRoot> Msgs { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci");

            OnMsBotModelCreatingPartial(modelBuilder);
        }

        private static void OnMsBotModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsgAggregateRoot>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("msg");

                entity.Property(e => e.Id).HasColumnType("bigint(20)").HasColumnName("id");
                entity.Property(e => e.Answer).HasMaxLength(1275).HasColumnName("answer");
                entity.Property(e => e.CreateId).HasMaxLength(255).HasColumnName("create_id");
                entity.Property(e => e.Link).HasMaxLength(1275).HasColumnName("link");
                entity.Property(e => e.Question).HasMaxLength(255).HasColumnName("question");
            });
        }
    }
}