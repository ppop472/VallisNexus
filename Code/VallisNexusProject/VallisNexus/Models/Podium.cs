using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using VallisNexus.DataAccess;
using VallisNexus.Models;

public class Podium
{
	public string naam { get; private set; }
	public string beschrijving { get; private set; }
	public int id { get; private set; }
    public List<Optreden> optredens { get; private set; } = new List<Optreden>();
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }
    
    public List<Podium> GetAllePodiumMetOptreden()
    {
        DBPodium dbPodium = new DBPodium();
        return dbPodium.GetAllePodiumMetOptreden();
    }

    public List<Optreden> GetAllePodiumMetFavorietOptreden()
    {
        DBPodium dbPodium = new DBPodium();
        DBFavoriet dbFavoriet = new DBFavoriet();
        DBOptreden dBOptreden = new DBOptreden();

        List<Optreden> optredenLijst = new List<Optreden>();
        List<int> optredenNrLijst = dbFavoriet.GetAlleFavorieten();
        foreach (int nummer in optredenNrLijst)
        {
            optredenLijst.Add(dBOptreden.GetEenOptredenMetId(nummer));
        }


        return optredenLijst;

    }
    public void VoegOptredenLijstToe(List<Optreden> optreden)
    {
        this.optredens = optreden;
    }
}
