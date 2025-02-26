namespace GrammyAwards.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Album { get; set; } // New property
        public int ReleaseYear { get; set; } // New property
        public int ArtistId { get; set; } // Foreign key for Artist
        public Artist? Artist { get; set; } // Navigation property
        public ICollection<Award>? Awards { get; set; } // One-to-Many relationship with Award
    }
}
