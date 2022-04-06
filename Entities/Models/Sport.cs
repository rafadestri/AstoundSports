using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Sport
    {
        [Required(ErrorMessage = "Calories burnt are a required field.")]
        public int CaloriesBurntByMinute { get; set; }

        [Required(ErrorMessage = "Duration is a required field.")]
        public int Duration { get; set; }

        [Column("SportId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Sport name is a required field.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Number of players is a required field.")]
        public int NumberOfPlayers { get; set; }
    }
}
