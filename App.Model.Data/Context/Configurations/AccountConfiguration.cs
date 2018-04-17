using System.Data.Entity.ModelConfiguration;

namespace App.Model.Data
{
    class AccountConfiguration:EntityTypeConfiguration<Account>
    {
        public AccountConfiguration()
        {
            HasMany(p => p.Images)
            .WithRequired(p => p.Account);

            HasMany(p => p.Files)
            .WithRequired(p => p.UploaderAccount);

            HasMany(p => p.Messages)
            .WithRequired(p => p.FromId);

        }
    }
}
