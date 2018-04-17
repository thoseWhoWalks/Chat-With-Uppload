using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Model.Data
{
    public class AccountInfo
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string Salt { get; set; }

        public Account Account { get; set; }
    }
}
