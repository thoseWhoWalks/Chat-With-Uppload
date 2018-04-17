namespace App.Model.Api
{
    public class AccountModelApi
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public ImageModelApi Img  { get; set; }
        public string ConnectionId { get; set; }
    }
}
