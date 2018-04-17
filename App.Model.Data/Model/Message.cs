using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Model.Data
{
    public class Message
    {
        public int Id { get; set; }

        public string Body { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public Account FromId { get; set; }
    }
}
