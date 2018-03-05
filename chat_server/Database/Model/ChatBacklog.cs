using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace chat_server.Database.Model
{
    [Table("ChatBacklogs")]
    public class ChatBacklog
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Id")]
        public User From { get; set; }

        public List<User>
    }
}
