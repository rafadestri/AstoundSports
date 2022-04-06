using System;

namespace Entities.DataTransferObjects
{
    public class SportForCreationDto
    {
        public int CaloriesBurntByMinute { get; set; }

        public int Duration { get; set; }

        public bool GroupSport { get => NumberOfPlayers > 1; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int NumberOfPlayers { get; set; }

        public int TotalEffort { get => NumberOfPlayers * Duration; }
    }
}
