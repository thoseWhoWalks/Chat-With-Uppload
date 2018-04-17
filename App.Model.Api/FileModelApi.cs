using App.Model.Api;

namespace App.Model
{
    public class FileModelApi
    {
        public int Id { get; set; }

        public string Path { get; set; } 
        
        public AccountModelApi Uploder { get; set; }
    }
}
