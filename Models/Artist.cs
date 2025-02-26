// Models/Artist.cs
namespace GrammyAwards.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>(); // One-to-Many relationship with Song

        // Computed property for the number of songs
        public int NumberOfSongs => Songs.Count;
    }
}