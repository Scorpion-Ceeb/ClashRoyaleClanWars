﻿using ClashRoyaleClanWarsAPI.Models;
using ClashRoyaleClanWarsAPI.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ClashRoyaleClanWarsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<BattleModel> Battles => Set<BattleModel>();
        public DbSet<CardModel> Cards => Set<CardModel>();
        public DbSet<ChallengeModel> Challenges => Set<ChallengeModel>();
        public DbSet<ClanModel> Clans => Set<ClanModel>();
        public DbSet<ClanWarsModel> ClanWars => Set<ClanWarsModel>();
        public DbSet<CollectModel> Collection => Set<CollectModel>();
        public DbSet<DonationModel> Donations => Set<DonationModel>();
        public DbSet<PlayerChallengesModel> PlayerChallenges => Set<PlayerChallengesModel>();
        public DbSet<PlayerClansModel> PlayerClans => Set<PlayerClansModel>();
        public DbSet<PlayerModel> Players => Set<PlayerModel>();
        public DbSet<SpellModel> Spells => Set<SpellModel>();
        public DbSet<StructureModel> Structures => Set<StructureModel>();
        public DbSet<TroopModel> Troops => Set<TroopModel>();
        public DbSet<WarModel> Wars => Set<WarModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BattleConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChallengeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClanWarsConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CollectConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DonationConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerChallengesConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerClanConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlayerConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WarConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TroopConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpellConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StructureConfiguration).Assembly);
        }

    }
}
