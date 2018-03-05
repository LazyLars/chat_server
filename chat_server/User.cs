﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;

namespace chat_server
{
    [Table("Users")]
    class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public IPAddress IpAdress { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime GeneratedAt { get; set; }
        public string Password { get; set; }

    }
}
