using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evim_Bu
{
    [Table("Table_User")]
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string E_Mail { get; set; }
        public string Password_Hash { get; set; }
        public string User_Role { get; set; }
    }
}