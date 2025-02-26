// DTOs/ArtistDTO.cs
namespace GrammyAwards.DTOs
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Nationality { get; set; } // New property
        public int? NumberOfSongs { get; set; } // New property
    }
}