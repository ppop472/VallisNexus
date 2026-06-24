using System;

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
    
    public Optreden(int Id, int ArtiestId, DateTime StartTijd, DateTime EindTijd, DateTime CreatedAt, DateTime UpdatedAt, DateTime DeletedAt, int PodiumId)
    {
        this.id = Id;
        this.artiestId = ArtiestId;
        this.starttijd = StartTijd;
        this.createdAt = CreatedAt;
        this.updatedAt = UpdatedAt;
        this.deletedAt = DeletedAt;
        this.podiumId = PodiumId;

    }
}
