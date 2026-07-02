using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using VallisNexus.DataAccess;
using VallisNexus.Models;

public class Optreden
{
	public int id { get; private set; }
    public Artiest artiest { get;  set; }
    public Podium podium { get; set; }
    public DateTime starttijd { get; private set; }
	public DateTime eindtijd { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }
    
    public Optreden(int? id, DateTime? startTijd, DateTime? eindTijd, DateTime? createdAt, DateTime? updatedAt, DateTime? deletedAt)
    { 
        this.id = id.Value;
        this.starttijd = startTijd.Value;
        this.eindtijd = eindTijd.Value;  
        this.createdAt= createdAt.Value;
        this.updatedAt = updatedAt.Value;
        this.deletedAt = deletedAt.Value;
    }

    //public OptredenDTO GetOptredenVoorFavoriete(int id)
    //{
    //    DBOptreden optreden = new DBOptreden();
    //    OptredenDTO optredenDto = optreden.GetOptredenVoorFavoriete(id);
    //    return optredenDto;
    //}
    //public List<Podium> GetAlleOptreden()
    //{
    //    DBOptreden dbOptreden = new DBOptreden();
    //    List<Podium> podiums = dbOptreden.GetOptreden();
    //    return podiums;
    //}
}
