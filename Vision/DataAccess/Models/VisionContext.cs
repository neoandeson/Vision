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

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountState> AccountState { get; set; }
        public virtual DbSet<BuyOrder> BuyOrder { get; set; }
        public virtual DbSet<Diary> Diary { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderHis> OrderHis { get; set; }
        public virtual DbSet<OrderHistory> OrderHistory { get; set; }
        public virtual DbSet<PriceSection> PriceSection { get; set; }
        public virtual DbSet<SellOrder> SellOrder { get; set; }
        public virtual DbSet<StockSymbol> StockSymbol { get; set; }
        public virtual DbSet<SystemConfig> SystemConfig { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(10);
            });

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
                entity.Property(e => e.BuyDate).HasColumnType("datetime");

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

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Note).HasMaxLength(300);

                entity.Property(e => e.RecordTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.MatchTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.SymbolName)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<OrderHis>(entity =>
            {
                entity.Property(e => e.MatchTime).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.OrderNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.SymbolName)
                    .IsRequired()
                    .HasMaxLength(10);
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

            modelBuilder.Entity<StockSymbol>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
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

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.RecordTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
