using System;

public class Genre
{
	public string naam { get; private set; };
	public int genreId { get; private set; };





    public Genre(string naam, int id)
	{
		this.naam = naam;
		this.genreId = id;

	}
}
