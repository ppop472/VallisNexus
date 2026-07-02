using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using VallisNexus.DataAccess;
using VallisNexus.Models;

public class Optreden
{
	public int id { get; private set; }
    public Artiest artiest { get; set; } = new Artiest();
    public Podium podium { get; set; }
    public DateTime starttijd { get; private set; }
	public DateTime eindtijd { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime? updatedAt { get; private set; } = null;
    public DateTime? deletedAt { get; private set; } = null;
    

    public Optreden()
    {

    }
    public Optreden(int id, DateTime startTijd, DateTime eindTijd, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt)
    { 
        this.id = id;
        this.starttijd = startTijd;
        this.eindtijd = eindTijd;  
        this.createdAt= createdAt;
        this.updatedAt = updatedAt;
        this.deletedAt = deletedAt;
    }

    // Dit is toegevoegd zodat bij programma tonen, bij rij 43 de OptredenDTO ook de artiesten meekrijgt. De bevenstaande is voor de DBOptreden als ik de nieuwe Optreed aanmaak.
    public Optreden(int id, DateTime startTijd, DateTime eindTijd, DateTime createdAt, DateTime? updatedAt, DateTime? deletedAt, Artiest artiest)
    {
        this.id = id;
        this.starttijd = startTijd;
        this.eindtijd = eindTijd;
        this.createdAt = createdAt;
        this.updatedAt = updatedAt;
        this.deletedAt = deletedAt;
        this.artiest = artiest;
    }
    public int GetAantalOptredens()
    {
        DBOptreden dBOptreden = new DBOptreden();
        return dBOptreden.GetAantalOptredens();
    }

    public void VoegArtiestToe(Artiest artiest)
    {
        this.artiest = artiest;
    }

    public void VoegFavorieteOptredenToe(OptredenDTO optreden)
    {
        DBFavoriet dbFavoriet = new DBFavoriet();
        dbFavoriet.VoegFavorietToe(optreden);
    }

    public List<Optreden> GetAlleFaviorieteOptreden()
    {
        DBFavoriet dbFavoriet = new DBFavoriet();
        return dbFavoriet.GetAlleFavorietOptreden();
    }

    public void VerwijderFavorieteOptreden(OptredenDTO optredenDto)
    {
        DBFavoriet dbFavoriet = new DBFavoriet();
        dbFavoriet.FavorietVerwijderen(optredenDto.id);
    }
}
