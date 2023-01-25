namespace WikiF1.API.Models;

public class Track
{
    public int Id { get; set; }
    
    public string Country { get; set; }
    
    public string Name { get; set; }
    
    public string PictureUrl { get; set; }
    
    public DateTime BeginYearInF1 { get; set; }
    
    public int NbRaces { get; set; }
    
    public DateTime NextGPDate { get; set; }
}