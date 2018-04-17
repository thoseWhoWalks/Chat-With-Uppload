using System.Linq;
using App.Model.Data;

namespace App.Model.Services
{
    public class ImageService : ServiceBaseModelList<ImageModelApi>
    {
        public ImageService(DB_Context context) : base(context)
        {
        }

        public override ImageModelApi Get(int id)
        {
            var res = db_context.Images.FirstOrDefault(img => img.Id == id && img.IsDeleted != true);

            if (res == null)
                return null;

            return new ImageModelApi
            {
                Id = res.Id,
                Path = res.OriginPath + res.Extention,
                Upploader = Mapper.ToAccountModelApi(res.Account, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == res.Account.Id))
            };
        }

        public override ImageModelApi Delete(ImageModelApi model)
        {
            var res = db_context.Images.FirstOrDefault(img => img.Id == model.Id && img.IsDeleted != true);

            if (res == null)
                return null;

            res.IsDeleted = true;

            db_context.SaveChanges();

            return Get(res.Id);
        }

        public override ImageModelApi Create(ImageModelApi model)
        {
            var img = new Image
            {
                Path = model.Path,
                Account = Mapper.ToAccountModel(model.Upploader),
                Extention = model.Path.TrimStart('.'),
                OriginPath = model.Path.TrimEnd('.')
            };

            db_context.Images.Add(img);
            db_context.SaveChanges();

            return Get(img.Id);

        }

        public override ImageModelApi Update(ImageModelApi model)
        {
            var res = db_context.Images.FirstOrDefault(img => img.Id == model.Id && img.IsDeleted != true);

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
