using System;
using System.Collections.Generic;
using VallisNexus.DataAccess;
using VallisNexus.Models;

public class Optreden
{
	public int id { get; private set; }
    public  int artiestId { get; private set; }
    public int podiumId { get; private set; }
    public DateTime starttijd { get; private set; }
	public DateTime eindtijd { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }
    

    public OptredenDTO GetOptredenVoorFavoriete(int id)
    {
        DBOptreden optreden = new DBOptreden();
        OptredenDTO optredenDto = optreden.GetOptredenVoorFavoriete(id);
        return optredenDto;
    }
    public List<Podium> GetAlleOptreden()
    {
        DBOptreden dbOptreden = new DBOptreden();
        List<Podium> podiums = dbOptreden.GetOptreden();
        return podiums;
    }
}
