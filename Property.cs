using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evim_Bu
{
    [Table("Table_Property")]
    public class Property
    {
        [Key]
        public int Property_id { get; set; }
        public int Category_id { get; set; }
        public int Host_id { get; set; }
        public string Title { get; set; }
        public decimal Price_Per_Night { get; set; }
        public bool? Is_My_Property { get; set; }

        public Category Category
        {
            get => default;
            set
            {
            }
        }
    }
}