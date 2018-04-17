namespace App.Model.Data
{
    public class File
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public bool IsDeleted { get; set; }

        public string Extention { get; set; }

        public string OriginPath { get; set; }
        
        public Account UploaderAccount { get; set; }
    }
}
//change manifests