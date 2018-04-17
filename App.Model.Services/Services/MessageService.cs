using System.Collections.Generic;
using System.Linq;
using App.Model.Data;

namespace App.Model.Services
{
    public class MessageService : ServiceBaseModelList<MessageModelApi>
    {
        public MessageService(DB_Context context) : base(context)
        {
        }

        public override MessageModelApi Create(MessageModelApi model)
        {
            var msg = new Message { Body = model.Body, FromId = UnitOfWork.Instance.AccountService.GetDbModel(UnitOfWork.Instance.AccountService.CurrentUser.Id) };

            db_context.Messages.Add(msg);
            db_context.SaveChanges();

            return new MessageModelApi { Body = msg.Body, Id = msg.Id, FromId = Mapper.ToAccountModelApi(msg.FromId, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == msg.FromId.Id)) };
       
        }

        public override MessageModelApi Update(MessageModelApi model)
        {
            var msg = db_context.Messages.FirstOrDefault(m => m.IsDeleted != true && m.Id == model.Id);

            msg.Body = model.Body;

            db_context.SaveChanges();

            return new MessageModelApi { Body = msg.Body, Id = msg.Id, FromId = Mapper.ToAccountModelApi(msg.FromId, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == msg.FromId.Id)) };
        }

    public override MessageModelApi Delete(MessageModelApi model)
    {
        var msg = db_context.Messages.FirstOrDefault(m => m.IsDeleted != true && m.Id == model.Id);

        msg.IsDeleted = true;
        db_context.SaveChanges();

        return new MessageModelApi { Body = msg.Body, Id = msg.Id, FromId = Mapper.ToAccountModelApi(msg.FromId, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == msg.FromId.Id)) };
        }

        public override MessageModelApi Get(int id)
        {
            var msg = db_context.Messages.FirstOrDefault(m => m.Id == id && m.IsDeleted != true);
            return new MessageModelApi { Body = msg.Body, Id = msg.Id, FromId = Mapper.ToAccountModelApi(msg.FromId, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == msg.FromId.Id)) };
    }

        public override ICollection<MessageModelApi> GetList()
        {
            var msgs = db_context.Messages.ToList();

            List<MessageModelApi> res = new List<MessageModelApi>();

            foreach(var msg in msgs)
            {
                res.Add(new MessageModelApi { Body = msg.Body, Id = msg.Id, FromId = Mapper.ToAccountModelApi(msg.FromId, db_context.AccountInfos.FirstOrDefault(ai => ai.Id == msg.FromId.Id)) });

        }

            return res;
        }

    }
}
