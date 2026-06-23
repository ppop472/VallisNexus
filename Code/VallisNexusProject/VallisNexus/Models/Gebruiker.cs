using System;
using System.Collections.Generic;

public class Gebruiker
{
	public string naam { get; private set; }
	public int id { get; private set; }
	public List<Optreden> favorieteOptredens { get; private set; }

    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }


    public Gebruiker(string naam, int id)
	{
		this.naam = naam;
		this.id = id;
		this.favorieteOptredens = new List<Optreden>();

    }

	public void VoegFavorieteOptredenToe(Optreden optreden)
	{
		favorieteOptredens.Add(optreden);
    }

	public void VerwijderFavorieteOptreden(Optreden optreden)
	{
		favorieteOptredens.Remove(optreden);
    }

	public string ToonFavorieteOptredens()
	{
		string optredens = "";
		foreach (Optreden optreden in favorieteOptredens)
		{
			optredens += optreden.ToString() + "\n";
		}
		return optredens;
    }
}
