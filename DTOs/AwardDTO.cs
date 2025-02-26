namespace GrammyAwards.DTOs
{
    public class AwardDTO
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public int SongId { get; set; } // Foreign key for Song
        public string? SongTitle { get; set; } // Song title for display
        public string? ArtistName { get; set; } // Artist name for display
    }
}