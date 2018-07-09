using App.Model.Api;
using App.Model.Data;

namespace App.Model.Services
{
    internal class Mapper
    {
        private Mapper()
        {

        }
         

        #region AccountMapping 
        internal static AccountModelApi ToAccountModelApi(Account model,AccountInfo modelInfo)
        {
            return new AccountModelApi
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName,
                Login = modelInfo.Email
            };
        }

        internal static Account ToAccountModel(AccountModelApi model)
        {
            return new Account
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.FirstName
            };
        }
        #endregion

        #region ImageMapping 

        //internal static ImageModelApi ToImageModelApi(Image model)
        //{
        //    return new ImageModelApi
        //    {
        //        Id = model.Id,
        //        Path = model.Path,
        //         Upploader = ToAccountModelApi(model.Account),
        //    }

        //}

        #endregion
    }
}
