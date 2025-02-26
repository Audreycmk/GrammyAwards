namespace GrammyAwards.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int ArtistId { get; set; }
        public string? ArtistName { get; set; } // For displaying artist name in views
    }
}
