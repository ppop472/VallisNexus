using System;

public class Podium
{
	public string naam { get; private set; }
	public string beschrijving { get; private set; }
	public int id { get; private set; }

    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }



    public Podium(string naam, string beschrijving)
	{
		this.naam = naam;
		this.beschrijving = beschrijving;

    }

    public void VoegOptredenToe(Optreden optreden)
    {
        
    }
}
