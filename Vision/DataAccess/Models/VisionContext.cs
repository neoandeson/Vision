using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataService.Models
{
    public partial class VisionContext : DbContext
    {
        public VisionContext()
        {
        }

        public VisionContext(DbContextOptions<VisionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountState> AccountState { get; set; }
        public virtual DbSet<BuyOrder> BuyOrder { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<PriceSection> PriceSection { get; set; }
        public virtual DbSet<SellOrder> SellOrder { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UH7HU37\\TIENTPSQL;Database=Vision;User ID=sa;Password=1234;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountState>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentPrice).HasColumnType("money");

                entity.Property(e => e.CurrentValue).HasColumnType("money");

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.TotalBuy).HasColumnType("money");

                entity.Property(e => e.TotalBuyFee).HasColumnType("money");

                entity.Property(e => e.TotalDividend).HasColumnType("money");

                entity.Property(e => e.TotalSell).HasColumnType("money");

                entity.Property(e => e.TotalSellFee).HasColumnType("money");

                entity.Property(e => e.TotalTax).HasColumnType("money");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BuyOrder>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(17);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.TradingFee).HasColumnType("money");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderHistory>(entity =>
            {
                entity.Property(e => e.BuyPrice).HasColumnType("money");

                entity.Property(e => e.BuyTradingFee).HasColumnType("money");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Margin).HasColumnType("money");

                entity.Property(e => e.Revenue).HasColumnType("money");

                entity.Property(e => e.SellPrice).HasColumnType("money");

                entity.Property(e => e.SellTax).HasColumnType("money");

                entity.Property(e => e.SellTradingFee).HasColumnType("money");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.TotalFee).HasColumnType("money");
            });

            modelBuilder.Entity<PriceSection>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<SellOrder>(entity =>
            {
                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(17);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Symbol)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.Property(e => e.TradingFee).HasColumnType("money");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("money");
            });

            modelBuilder.Entity<SystemConfig>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StringValue)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
