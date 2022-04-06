using System;

namespace Entities.DataTransferObjects
{
    public class AthleteForCreationDto
    {
        public int Age { get; set; }

        public string Country { get; set; }

        public Guid Id { get; set; }
        public int MaximumCalories { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
    }
}
