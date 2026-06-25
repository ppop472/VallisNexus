using System;
using System.Collections.Generic;
using VallisNexus.Models;

public class Podium
{
	public string naam { get; private set; }
	public string beschrijving { get; private set; }
	public int id { get; private set; }
    public List<OptredenDTO> optreden { get; set; } = new List<OptredenDTO>();
    public DateTime createdAt { get; private set; }
    public DateTime updatedAt { get; private set; }
    public DateTime deletedAt { get; private set; }
    
}
