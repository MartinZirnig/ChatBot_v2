using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ModelsMl.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsMl.Data
{
    internal class DatabaseConnection: DbContext
    {
        public DbSet<Conversations> Conversations { get; set; }
        public DbSet<Emotions> Emotions { get; set; }
        public DbSet<Formats> Formats { get; set; }
        public DbSet<Intends> Intends { get; set; }
        public DbSet<Purposes> Purposes { get; set; }
        public DbSet<Inputs> Inputs { get; set; }
        public DbSet<Outputs> Outputs { get; set; }
        public DbSet<Informations> Informations { get; set; }


        internal static readonly string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "sources.db");
        internal static readonly string DbBackupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database", "Db_Backup");


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);
            Directory.CreateDirectory(DbBackupPath);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                foreach (var foreignKey in entityType.GetForeignKeys())
                    foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
        }


        public void Restore(string name)
        {
            string backupPath = Path.Combine(DbBackupPath, name, $"{name}.dbBack");
            if (File.Exists(backupPath))
            {
                using (var backup = new SqliteConnection($"Data Source={backupPath}"))
                {
                    using (var original = new SqliteConnection($"Data Source={DbPath}"))
                    {
                        backup.Open();
                        original.Open();
                        backup.BackupDatabase(original);
                    }
                }
            }
        }
        public void Backup(string name)
        {
            string backupPath = Path.Combine(DbBackupPath, name, $"{name}.dbBack");
            Directory.CreateDirectory(Path.GetDirectoryName(backupPath)!);
            using (var original = new SqliteConnection($"Data Source={DbPath}"))
            {
                using (var backup = new SqliteConnection($"Data Source={backupPath}"))
                {
                    original.Open();
                    backup.Open();
                    original.BackupDatabase(backup);
                }
            }
        }
        public void Clear()
        {
            Backup($"ClBckDb_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}");
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }


    }
}
