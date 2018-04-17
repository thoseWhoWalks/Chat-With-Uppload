namespace App.Model.Data
{
    public class Image
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Extention { get; set; }

        public string OriginPath { get; set; }

        public bool IsDeleted { get; set; }

        public Account Account { get; set; }
    }
}
