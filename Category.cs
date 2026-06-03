using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evim_Bu
{
    [Table("Table_Category")]
    public class Category
    {
        [Key]
        public int Category_id { get; set; }

        [MaxLength(50)]
        public string Category_name { get; set; }
    }
}