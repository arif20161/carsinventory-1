using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsInventory.Models
{
    public class Car
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2050, ErrorMessage = "Year must be between 1900 and 2050")]
        public int Year { get; set; }

        [Required]
        public decimal Price{ get; set; }

        public bool New { get; set; }

        public Guid UserId { get; set; }

        /*
        [ForeignKey("UserId")]
        public virtual UserProfile CreatedBy { get; set; }
        */

    }
}