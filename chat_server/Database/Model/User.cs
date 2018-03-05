using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;

namespace chat_server.Database.Model
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string IpAdress { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime GeneratedAt { get; set; }
        public string Password { get; set; }

        public ICollection<ChatBacklog> ChatBacklog { get; set; }

    }
}
