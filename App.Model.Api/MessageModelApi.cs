using App.Model.Api;

namespace App.Model
{
    public class MessageModelApi
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public AccountModelApi FromId { get; set; }
    }
}
