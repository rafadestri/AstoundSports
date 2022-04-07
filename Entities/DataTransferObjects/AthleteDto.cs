using System;

namespace Entities.DataTransferObjects
{
    public class AthleteDto
    {
        public int Age { get; set; }

        public int BurntCalories { get; set; }
        public bool CanCompete { get; set; }

        public bool CanPractice { get; set; }

        public string Country { get; set; }

        public string FullName { get; set; }
        public Guid Id { get; set; }

        public int MaximumCalories { get; set; }
    }
}
