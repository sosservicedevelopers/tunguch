using System;
using System.Collections.Generic;
using System.Text;
using AisMKIT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace AisMKIT.Data
{
    

   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Dictionary
        public DbSet<Departments> Departments { get; set; }
        public DbSet<DictRegion> DictRegion { get; set; }
        public DbSet<DictDistrict> DictDistrict { get; set; }
        public DbSet<DictLegalForm> DictLegalForm { get; set; }
        public DbSet<DictFinSource> DictFinSource { get; set; }
        public DbSet<DictMediaType> DictMediaType { get; set; }
        public DbSet<DictMediaDistribTerritory> DictMediaDistribTerritory { get; set; }
        public DbSet<DictMediaLangType> DictMediaLangType { get; set; }
        public DbSet<DictMediaFreqRelease> DictMediaFreqRelease { get; set; }
        public DbSet<DictAgencyPerm> DictAgencyPerm { get; set; }
        public DbSet<DictControlType> DictControlType { get; set; }
        public DbSet<DictMediaControlResult> DictMediaControlResult { get; set; }
        public DbSet<DictMediaSuitPerm> DictMediaSuitPerm { get; set; }
        public DbSet<DictStatus> DictStatus { get; set; }

        #endregion

        #region Media
        public DbSet<ListOfMedia> ListOfMedia { get; set; }
        public DbSet<ListOfControlMedia> ListOfControlMedia { get; set; }
        public DbSet<ListOfTeleRadio> ListOfTeleRadio { get; set; }
        public DbSet<ListOfMediaHistory> ListOfMediaHistory { get; set; }

        #endregion

        #region TZY
        public DbSet<ListOfTheatrical> ListOfTheatrical { get; set; }
        public DbSet<ListOfCouncilTheatrical> ListOfCouncilTheatrical { get; set; }
        public DbSet<ListOfEventsTheatrical> ListOfEventsTheatrical { get; set; }
        public DbSet<DictTheatricalHall> DictTheatricalHall { get; set; }
        public DbSet<ListOfTheatricalHistory> ListOfTheatricalHistory { get; set; }


        #endregion

        #region EduInst
        public DbSet<ListOfEduInstituts> ListOfEduInstituts { get; set; }
        public DbSet<DictEduInstType> DictEduInstType { get; set; }

        #endregion

        #region Tourizm
        public DbSet<ListOfTourism> ListOfTourism { get; set; }
        public DbSet<ListOfTourismIndicator> ListOfTourismIndicator { get; set; }
        public DbSet<ListOfTourismHistory> ListOfTourismHistory { get; set; }
        public DbSet<ListOfTourismServices> ListOfTourismServices { get; set; }
        public DbSet<DictTourismServices> DictTourismServices { get; set; }

        #endregion

        #region Cinematography
        public DbSet<ListOfCinematography> ListOfCinematography { get; set; }
        public DbSet<ListOfCinematographyHistory> ListOfCinematographyHistory { get; set; }
        public DbSet<ListOfCinematographyServices> ListOfCinematographyServices { get; set; }
        public DbSet<DictCinematographyServices> DictCinematographyServices { get; set; }
        public DbSet<ListOfCinematographyDocuments> ListOfCinematographyDocuments { get; set; }
        

        public DbSet<DictCountry> DictCountry { get; set; }
        public DbSet<ListOfCinematographyCertificates> ListOfCinematographyCertificates { get; set; }
        public DbSet<DictCinemaAgeRestrictions> DictCinemaAgeRestrictions { get; set; }
        public DbSet<DictCinemaRegiser> DictCinemaRegiser { get; set; }
         public DbSet<DictCinemaDuration> DictCinemaDuration { get; set; }
        // промежуточные таблицы
        public DbSet<CinemaCountries> CinemaCountries { get; set; }
        public DbSet<CinemaRegisers> CinemaRegisers { get; set; }

        #endregion

        #region Monumetns
        public DbSet<ListOfMonuments> ListOfMonuments { get; set; }
        public DbSet<ListOfMonumentsProtObjects> ListOfMonumentsProtObjects { get; set; }
        public DbSet<DictMonumemtSignOfLoss> DictMonumemtSignOfLoss { get; set; }
        public DbSet<DictMonumentType> DictMonumentType { get; set; }
        public DbSet<ListOfMonumetnTypologicalAccessory> ListOfMonumetnTypologicalAccessory { get; set; }
        public DbSet<DictMonumentTypologicalType> DictMonumentTypologicalType { get; set; }
        #endregion

        #region Library
        public DbSet<ListOfLibraryIndicators> ListOfLibraryIndicators { get; set; }
        #endregion


        #region CultAndArts

        public DbSet<ListOfCultAndArt> ListOfCultAndArt { get; set; }
        public DbSet<DictCultAndArtType> DictCultAndArtType { get; set; }
        #endregion



        #region StateAwards

        public DbSet<ListOfStateAwards> ListOfStateAwards { get; set; }
        public DbSet<DictStateAwardsType> DictStateAwardsType { get; set; }
        public DbSet<DictAwardsPosition> DictAwardsPosition { get; set; }
        public DbSet<DictAwardsReason> DictAwardsReason { get; set; }

        #endregion

        #region Rent

        public DbSet<ListOfRentsHistory> ListOfRentsHistory { get; set; }
        public DbSet<ListOfRents> ListOfRents { get; set; }
        public DbSet<DictRentObjectType> DictRentObjectType { get; set; }
        public DbSet<DictUnitOfMeasure> DictUnitOfMeasure { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Seed();

            //modelBuilder.Entity<CinemaCountries>()
            //            .HasMany(c => c.ListOfCinematographyCertificates)
            //            .WithOne(e => e.CinemaCountries)
            //            .HasForeignKey(e => e.StoreId)
            //            .IsRequired();

            //modelBuilder.Entity<CinemaCountries>()
            //               .HasOne(s => s.ListOfCinematographyCertificates)
            //               .WithMany(c => c.CinemaCountries)
            //               .HasForeignKey(s => s.ListOfCinematographyCertificatesId)
            //               .IsRequired();


            //modelBuilder.Entity<CinemaCountries>()
            //               .HasOne(s => s.DictCountry)
            //               .WithMany(c => c.CinemaCountries)
            //               .HasForeignKey(s => s.DictCountryId)
            //               .IsRequired();

            //modelBuilder.Entity<ListOfCinematographyCertificates>()
            //               .HasOne(s => s.CinemaCountries.FirstOrDefault())
            //               .WithMany()
            //               .HasForeignKey(s => s.CinemaCountries.FirstOrDefault().Id);


        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Для postgresql
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql("Host=192.168.145.130;Port=5432;Database=AisMKIT;Username=postgres;Password=admin");
            //  optionsBuilder.UseNpgsql("Host=212.112.106.181;Port=5432;Database=aismkitdb;Username=postgres;Password=dbPwdAdmin");
            //optionsBuilder.UseNpgsql("Host=192.168.161.130;Port=5432;Database=aismkitdb;Username=postgres;Password=dbPwdAdmin");
            // optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=aismkitdb;Username=postgres;Password=dbPwdAdmin");
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=aismkitdb2;Username=postgres;Password=dbPwdAdmin");

        }
        //Для postgresql
        public DbSet<AisMKIT.Models.DictTypeOfKMM> DictTypeOfKMM { get; set; }
        //Для postgresql
        public DbSet<AisMKIT.Models.DictLoc> DictLoc { get; set; }
        //Для postgresql
        public DbSet<AisMKIT.Models.DictInitiatorOfProj> DictInitiatorOfProj { get; set; }
        //Для postgresql
        public DbSet<AisMKIT.Models.ListOfCultEvents> ListOfCultEvents { get; set; }
        //Для postgresql
        public DbSet<AisMKIT.Models.ListOfEvents> ListOfEvents { get; set; }
        //Для postgresql
      
         
    }
}
