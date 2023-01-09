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

        public virtual DbSet<MsgSummaryAggregateRoot> MsgSummaries { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, MySqlServerVersion.Parse("5.6.50"));
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

            modelBuilder.Entity<MsgSummaryAggregateRoot>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PRIMARY");

                entity.ToTable("msg_summary");

                entity.HasIndex(e => new { e.Day, e.Month, e.Year }, "IDX_day");

                entity.HasIndex(e => new { e.Hour, e.Day, e.Month, e.Year }, "IDX_hour");

                entity.HasIndex(e => new { e.Month, e.Year }, "IDX_month");

                entity.HasIndex(e => e.Year, "IDX_year");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");
                entity.Property(e => e.GroupId).HasColumnType("bigint(20)").HasColumnName("group_id");
                entity.Property(e => e.Count).HasColumnType("bigint(20)").HasColumnName("count");
                entity.Property(e => e.Day).HasColumnType("int(11)").HasColumnName("day");
                entity.Property(e => e.Hour).HasColumnType("int(11)").HasColumnName("hour");
                entity.Property(e => e.Month).HasColumnType("int(11)").HasColumnName("month");
                entity.Property(e => e.Year).HasColumnType("int(11)").HasColumnName("year");
            });

        }
    }
}