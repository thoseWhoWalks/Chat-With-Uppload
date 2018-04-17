using System.Data.Entity;

namespace App.Model.Data
{
    public class DB_Context : DbContext
    {
        public DB_Context() : base("DbConnection")
        { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountInfo> AccountInfos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Message> Messages { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
   
            modelBuilder.Conventions.Add(new NameConvention());

            modelBuilder.Conventions.Add(new PathConvention());

            modelBuilder.Configurations.Add(new AccountInfoConfiguration()); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
