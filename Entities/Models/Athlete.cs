using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Athlete
    {
        [Required(ErrorMessage = "Age is a required field.")]
        public int Age { get; set; }

        public string Country { get; set; }

        [Column("AthleteId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The maximum number of calories a athlete can burn is a required field.")]
        public int MaximumCalories { get; set; }

        [Required(ErrorMessage = "Athlete name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Athlete surname is a required field.")]
        public string SurName { get; set; }
    }
}
