using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vote.Model;

namespace Vote.Data.DB
{
   
    public class VoteDBContext : DbContext
    {
        public VoteDBContext(DbContextOptions<VoteDBContext> options)
            : base(options)
        {
        }

        public DbSet<AdminUsers> adminUsers { get; set; }
        public DbSet<Elections> elections { get; set; }
        public DbSet<Candidates> candidates { get; set; }
        public DbSet<FileUpload> fileUpload { get; set; }
        public DbSet<VoteData> voteData { get; set; }
        public DbSet<Voters> voters { get; set; }
        public DbSet<UCustomers> uCustomers { get; set; }
        public DbSet<UDrivers> uDrivers { get; set; }
        public DbSet<UOrders> uOrders { get; set; }
        public DbSet<UProduct> uProduct { get; set; }
        public DbSet<UBProduct> uBProduct { get; set; }
        public DbSet<LuckydrawPrize> luckydrawPrize { get; set; }

        public DbSet<LuckydrawUser> luckydrawUser { get; set; }
        public DbSet<LuckydrawGame> luckydrawGame { get; set; }
        public DbSet<LuckydrawGamePrize> luckydrawGamePrize { get; set; }
        public DbSet<LuckydrawUserPrize> luckydrawUserPrize { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminUsers>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedOn);
            });
            modelBuilder.Entity<Elections>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Description);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedOn);
            });
            modelBuilder.Entity<Candidates>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.ElectionId);
                entity.Property(e => e.FatherName);
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Address);
                entity.Property(e => e.Image);
                entity.Property(e => e.Proof);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.Adhar);
            });
            modelBuilder.Entity<FileUpload>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.ImageUrl);
            });
            modelBuilder.Entity<VoteData>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.CandidateId);
                entity.Property(e => e.ElectionId);
                entity.Property(e => e.VoterId);
                entity.Property(e => e.CreatedOn);
            });
            modelBuilder.Entity<Voters>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.FatherName);
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Address);
                entity.Property(e => e.Image);
                entity.Property(e => e.Proof);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.Adhar);
                entity.Property(e => e.Password);
            });
            modelBuilder.Entity<UCustomers>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.FullName);
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Otp);
            });
            modelBuilder.Entity<UDrivers>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.FullName);
                entity.Property(e => e.Email);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Password);
                entity.Property(e => e.Lat);
                entity.Property(e => e.Lng);
                entity.Property(e => e.DeviceToken);
                entity.Property(e => e.DeviceType);
            });
            modelBuilder.Entity<UOrders>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.CustomerId);
                entity.Property(e => e.DriverId);
                entity.Property(e => e.FromLat);
                entity.Property(e => e.FromLng);
                entity.Property(e => e.ToLat);
                entity.Property(e => e.ToLng);
                entity.Property(e => e.Price);
                entity.Property(e => e.OrderStatus);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.Img);
            });
            modelBuilder.Entity<UProduct>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Title);
                entity.Property(e => e.Image);
                entity.Property(e => e.Description);
                entity.Property(e => e.Price);
                entity.Property(e => e.Ratecount);
                entity.Property(e => e.Category);
              
            });
            modelBuilder.Entity<UBProduct>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.PName);

                
            });


            modelBuilder.Entity<LuckydrawUser>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.FullName);
                entity.Property(e => e.FatherName);
                entity.Property(e => e.Phone);
                entity.Property(e => e.Email);
                entity.Property(e => e.Password);
                entity.Property(e => e.Gender);
                entity.Property(e => e.Department);
                entity.Property(e => e.Designation);
                entity.Property(e => e.Img);
                entity.Property(e => e.IsAdmin);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.IsActive);
            });
            modelBuilder.Entity<LuckydrawPrize>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.PrizeName);
                entity.Property(e => e.PrizePurpose);
                entity.Property(e => e.PrizeAmount);
                entity.Property(e => e.PrizeImageId);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.PrizeType);
                entity.Property(e => e.PrizeEmotion);
            });

            modelBuilder.Entity<LuckydrawGame>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.GameName);
                entity.Property(e => e.GameDescription);
                entity.Property(e => e.ToDate);
                entity.Property(e => e.FromDate);
                entity.Property(e => e.CreatedOn);
                entity.Property(e => e.ImgId);
            });
            modelBuilder.Entity<LuckydrawGamePrize>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.GameId);
                entity.Property(e => e.PrizeId);
                entity.Property(e => e.CreatedOn);
            });
            modelBuilder.Entity<LuckydrawUserPrize>(entity =>
            {
                entity.Property(e => e.Id);
                entity.Property(e => e.UserId);
                entity.Property(e => e.GameId);
                entity.Property(e => e.PrizeId);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.CreatedOn);
            });
        }
    }
}
