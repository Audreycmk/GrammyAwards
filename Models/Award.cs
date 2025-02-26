namespace GrammyAwards.Models
{
    public enum AwardStatus
    {
        Nominated,
        Won,
        Pending
    }

    public class Award
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public int SongId { get; set; } // Foreign key for Song
        public Song? Song { get; set; } // Navigation property
        public AwardStatus Status { get; set; } // New property for award status
    }
}
