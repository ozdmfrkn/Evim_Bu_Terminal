using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evim_Bu
{
    [Table("Table_Booking")]
    public class Booking
    {
        [Key]
        public int Booking_id { get; set; }

        public int Property_id { get; set; }
        public int Guest_id { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }

        public User User
        {
            get => default;
            set
            {
            }
        }

        public Property Property
        {
            get => default;
            set
            {
            }
        }
    }
}