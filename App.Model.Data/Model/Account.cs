using System;
using System.Collections.Generic;

namespace App.Model.Data
{
    public class Account
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; } 

        public bool IsDeleted { get; set; }

        public AccountInfo AccountInfo { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<File> Files { get; set; }

        public ICollection<Message> Messages { get; set; }

        public Account()
        {
            Images = new List<Image>();

            Files = new List<File>();

            Messages = new List<Message>();
        }
    }
}
