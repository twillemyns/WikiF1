namespace WikiF1.API.Models;

public class Team
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string LogoUrl { get; set; }
    
    public int Driver1Id { get; set; }
    
    public int Driver2Id { get; set; }
    
    public int TeamPrincipalId { get; set; }
    
    public int RecordId { get; set; }
}