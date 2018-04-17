using System.Linq;
using App.Model.Data;

namespace App.Model.Services
{
    public class FileService : ServiceBaseModelList<FileModelApi>
    {
        public FileService(DB_Context context) : base(context)
        {
        }

        public override FileModelApi Get(int id)
        {
            var res = db_context.Images.FirstOrDefault(f => f.Id == id && f.IsDeleted != true);

            if (res == null)
                return null;

            return new FileModelApi
            {
                Id = res.Id,
                Path = res.OriginPath + res.Extention,
                Uploder = Mapper.ToAccountModelApi(res.Account, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == res.Account.Id))
            };
        }

        public override FileModelApi Delete(FileModelApi model)
        {
            var res = db_context.Images.FirstOrDefault(img => img.Id == model.Id && img.IsDeleted != true);

            if (res == null)
                return null;

            res.IsDeleted = true;

            db_context.SaveChanges();

            return Get(res.Id);
        }

        public override FileModelApi Create(FileModelApi model)
        {
            var file = new Image
            {
                Path = model.Path,
                Account = Mapper.ToAccountModel(model.Uploder),
                Extention = model.Path.TrimStart('.'),
                OriginPath = model.Path.TrimEnd('.')
            };

            db_context.Images.Add(file);
            db_context.SaveChanges();

            return Get(file.Id);

        }

        public override FileModelApi Update(FileModelApi model)
        {
            var res = db_context.Images.FirstOrDefault(f => f.Id == model.Id && f.IsDeleted != true);

            if (res == null)
                return null;

            res.Path = model.Path;
            res.OriginPath = model.Path.TrimEnd('.');
            res.Extention = model.Path.TrimStart('.');

            db_context.SaveChanges();

            return Get(res.Id);
        }
    }
}
