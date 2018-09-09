namespace VaporStore.Data.Models
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class Game
    {
	    public int Id { get; set; }

	    [Required]
	    public string Name { get; set; }

	    [Required]
	    [Range(typeof(decimal), "0", "79228162514264337593543950335")]
	    public decimal Price { get; set; }

	    [Required]
	    public DateTime ReleaseDate { get; set; }

	    [Required]
	    public int DeveloperId { get; set; }

	    public Developer Developer { get; set; }

	    [Required]
	    public int GenreId { get; set; }

	    public Genre Genre { get; set; }

	    public ICollection<Purchase> Purchases { get; set; }

	    public ICollection<GameTag> GameTags { get; set; }
	}
}
