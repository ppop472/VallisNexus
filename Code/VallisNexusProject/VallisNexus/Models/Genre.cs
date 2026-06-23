using System;

public class Genre
{
	public string naam { get; private set; }
	public int id { get; private set; }

    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }




    public Genre(string naam, int id)
	{
		this.naam = naam;
		this.id = id;

	}
}
