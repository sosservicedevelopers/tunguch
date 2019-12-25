using System;
using System.Collections.Generic;
using System.Text;
using AisMKIT.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<ListOfTourismHistory> ListOfTourismHistory { get; set; }
        public DbSet<ListOfTourismServices> ListOfTourismServices { get; set; }
        public DbSet<DictTourismServices> DictTourismServices { get; set; }

        #endregion

        #region Cinematography
        public DbSet<ListOfCinematography> ListOfCinematography { get; set; }
        public DbSet<ListOfCinematographyHistory> ListOfCinematographyHistory { get; set; }
        public DbSet<ListOfCinematographyServices> ListOfCinematographyServices { get; set; }
        public DbSet<DictCinematographyServices> DictCinematographyServices { get; set; }

        #endregion

        #region Monumetns
        public DbSet<ListOfMonuments> ListOfMonuments { get; set; }
        public DbSet<DictMonumemtSignOfLoss> DictMonumemtSignOfLoss { get; set; }
        public DbSet<DictMonumentType> DictMonumentType { get; set; }
        public DbSet<ListOfMonumetnTypologicalAccessory> ListOfMonumetnTypologicalAccessory { get; set; }
        public DbSet<DictMonumentTypologicalType> DictMonumentTypologicalType { get; set; }
        #endregion

        
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Для postgresql
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseNpgsql("Host=192.168.145.130;Port=5432;Database=AisMKIT;Username=postgres;Password=admin");
            // optionsBuilder.UseNpgsql("Host=212.112.106.181;Port=5432;Database=aismkitdb;Username=postgres;Password=dbPwdAdmin");
           // optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=aismkitdb;Username=postgres;Password=dbPwdAdmin");

        }
        //Для postgresql
         
    }
}
