namespace WikiF1.API.Models;

public class Person
{
    public int Id { get; set; }
    
    public string LastName { get; set; }
    
    public string FirstName { get; set; }
    
    public string PictureUrl { get; set; }
    
    public DateTime BirthDate { get; set; }
    
    public bool IsDriver { get; set; }
    
    public int TeamId { get; set; }
    
    public int RecordId { get; set; }
}