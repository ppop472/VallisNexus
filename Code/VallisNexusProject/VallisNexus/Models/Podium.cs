using System;
using System.Collections.Generic;

public class Podium
{
	public string naam { get; private set; }
	public string beschrijving { get; private set; }
	public int id { get; private set; }
    public List<Optreden> optreden { get; set; } = new List<Optreden>();
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }
    
}
