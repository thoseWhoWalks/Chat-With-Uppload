using App.Model.Api;
using App.Model.Data;
using System.Linq;
using System.Web.Helpers;

namespace App.Model.Services
{
    public class AccountServices : ServiceBaseModelList<AccountModelApi>
    {
        public AccountServices(DB_Context context) : base(context)
        {
        }

        private AccountModelApi _currUser;

        public AccountModelApi CurrentUser => _currUser ?? null;

        public override AccountModelApi Get(int id)
        {
            var account = db_context.Accounts.FirstOrDefault(a => a.Id == id && a.IsDeleted != true);

            return Mapper.ToAccountModelApi(account,db_context.AccountInfos.FirstOrDefault(ai=>ai.Id == account.Id));
        }

        internal Account GetDbModel(int id)
        {  
            return db_context.Accounts.FirstOrDefault(a => a.Id == id && a.IsDeleted != true);
        }

        public override AccountModelApi Create(AccountModelApi model)
        {
            string _salt = Crypto.GenerateSalt();
            string _password = Crypto.HashPassword(model.Password + _salt);

            var accInfo = new AccountInfo
            {
                Email = model.Login,
                Salt = _salt,
                HashPassword = _password
            };

            db_context.AccountInfos.Add(accInfo);
            db_context.SaveChanges();

            var acc = new Account
            {
                Id = accInfo.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            db_context.Accounts.Add(acc);
            db_context.SaveChanges();


            return Get(accInfo.Id);
        }

        public override AccountModelApi Update(AccountModelApi model)
        {
            var account = db_context.Accounts.FirstOrDefault(a => a.Id == model.Id && a.IsDeleted != true);

            if (account == null)
                return null;

            account.FirstName = model.FirstName;
            account.LastName = model.LastName;

            return Get(account.Id);

        }

        public override AccountModelApi Delete(AccountModelApi model)
        {
            var account = db_context.Accounts.FirstOrDefault(a => a.Id == model.Id && a.IsDeleted != true); 

            account.IsDeleted = true;
            db_context.SaveChanges();

            return Mapper.ToAccountModelApi(account, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == account.Id));
      
        }

        public AccountModelApi VerifyUser(string _password, string _login)
        {
            var user = db_context.AccountInfos.FirstOrDefault(a => a.Email == _login);

            if (user == null)
                return null;

            if (Crypto.VerifyHashedPassword(user.HashPassword, _password + user.Salt))
            { 
                var userModel =  Mapper.ToAccountModelApi(db_context.Accounts.FirstOrDefault(a => a.Id == user.Id),user);

                _currUser = userModel;

                return _currUser;
            }
            else return null;
        }
    }
}
