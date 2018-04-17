using System.Data.Entity.ModelConfiguration;

namespace App.Model.Data
{
    class AccountInfoConfiguration:EntityTypeConfiguration<AccountInfo>
    {
        public AccountInfoConfiguration()
        { 
            Property(p => p.HashPassword).IsRequired();
            Property(p => p.Salt).IsRequired();
            HasRequired(i => i.Account)
                .WithRequiredPrincipal(a => a.AccountInfo);
        }
    }
}
