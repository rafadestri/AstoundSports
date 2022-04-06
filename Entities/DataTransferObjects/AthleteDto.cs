using System;

namespace Entities.DataTransferObjects
{
    public class AthleteDto
    {
        public int Age { get; set; }

        public string Country { get; set; }

        public string FullName { get; set; }
        public Guid Id { get; set; }

        public int MaximumCalories { get; set; }
    }
}
