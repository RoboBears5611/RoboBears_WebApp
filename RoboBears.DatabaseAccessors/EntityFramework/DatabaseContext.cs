using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboBears.DatabaseAccessors.EntityFramework
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=RoboBears")
        {

        }

        public virtual DbSet<Year> Years { get; set; }

        public virtual DbSet<Competition> Competitions { get; set; }

        public virtual DbSet<Match> Matches { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Robot> Robots { get; set; }

        public virtual DbSet<Member> Members { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Strength> Strengths { get; set; }

        public virtual DbSet<StrengthQualityPair> StrengthQualityPair { get; set; }

        public virtual DbSet<Obstacle> Obstacles { get; set; }

        public virtual DbSet<Mat> Mats { get; set; }

        public virtual DbSet<ImageData> ImageData { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Description> Descriptions { get; set; }

        public virtual DbSet<CompetitionType> CompetitionTypes { get; set; }

        public virtual DbSet<MatchType> MatchTypes { get; set; }

        //public virtual DbSet<ObstacleImage> ObstacleImages { get; set; }

        //public virtual DbSet<RobotImage> RobotImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Relationships
            modelBuilder.Entity<Description>()
                .HasMany(e => e.Notes)
                .WithRequired(n => n.Description)
                .HasForeignKey(n => n.DescriptionId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Year>()
                .HasMany(y => y.Competitions)
                .WithRequired(c => c.year)
                .HasForeignKey(c => c.YearId);

            modelBuilder.Entity<Year>()
                .Property(y => y.YearId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Game>()
                .HasRequired(g => g.Year)
                .WithOptional(y => y.Game);

            modelBuilder.Entity<Game>()
                .HasKey(g => g.GameId);

            modelBuilder.Entity<Mat>()
                .HasKey(m => m.MatId);

            modelBuilder.Entity<Game>()
                .HasOptional(g => g.Mat)
                .WithRequired(m => m.Game);

            modelBuilder.Entity<Mat>()
                .HasMany(m => m.Obstacles)
                .WithRequired(o => o.Mat)
                .HasForeignKey(o => o.MatId);

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.Matches)
                .WithRequired(m => m.Competition)
                .HasForeignKey(m => m.CompetitionId);

            modelBuilder.Entity<Competition>()
                .HasRequired(c => c.CompetitionType)
                .WithMany(c => c.Competitions)
                .HasForeignKey(c => c.CompetitionTypeId);

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.Teams)
                .WithMany(t => t.Competitions);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.BlueAllianceTeam1)
                .WithMany(t => t.Blue1Matches)
                .HasForeignKey(m => m.BlueAllianceTeam1Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.BlueAllianceTeam2)
                .WithMany(t => t.Blue2Matches)
                .HasForeignKey(m => m.BlueAllianceTeam2Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.RedAllianceTeam1)
                .WithMany(t => t.Red1Matches)
                .HasForeignKey(m => m.RedAllianceTeam1Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.RedAllianceTeam2)
                .WithMany(t => t.Red2Matches)
                .HasForeignKey(m => m.RedAllianceTeam2Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.MatchType)
                .WithMany(m => m.Matches)
                .HasForeignKey(m => m.MatchTypeId);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Members)
                .WithRequired(m => m.Team)
                .HasForeignKey(m => m.TeamId);

            modelBuilder.Entity<Team>()
                .Property(t => t.TeamId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Strengths)
                .WithRequired(sqp => sqp.Team)
                .HasForeignKey(sqp => sqp.TeamId);

            modelBuilder.Entity<Team>()
                .HasOptional(t => t.Robot)
                .WithRequired(r => r.Team);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.Positions)
                .WithMany(p => p.Members);

            modelBuilder.Entity<Member>()
                .HasMany(m => m.YearsInTeam)
                .WithMany(y => y.Members);

            modelBuilder.Entity<Robot>()
                .HasMany(r => r.ObstacleStrengths)
                .WithRequired(oqp => oqp.Robot)
                .HasForeignKey(oqp => oqp.RobotId);

            modelBuilder.Entity<ObstacleQualityPair>()
                .HasRequired(oqp => oqp.Obstacle)
                .WithMany(o => o.ObstacleQualityPairs)
                .HasForeignKey(oqp => oqp.ObstacleId);

            modelBuilder.Entity<StrengthQualityPair>()
                .HasRequired(sqp => sqp.Strength)
                .WithMany(s => s.StrengthQualityPairs)
                .HasForeignKey(sqp => sqp.StrengthId);

            //modelBuilder.Entity<ObstacleImage>()
            //    .HasKey(oi => oi.ImageDataId)
            //    .HasKey(oi => oi.ObstacleId);

            //modelBuilder.Entity<RobotImage>()
            //    .HasKey(ri => ri.ImageDataId)
            //    .HasKey(ri => ri.RobotId);
            #endregion
        }

        public System.Data.Entity.DbSet<RoboBears.DatabaseAccessors.EntityFramework.Note> Notes { get; set; }

        public System.Data.Entity.DbSet<RoboBears.DatabaseAccessors.EntityFramework.ObstacleQualityPair> ObstacleQualityPairs { get; set; }
    }
}
