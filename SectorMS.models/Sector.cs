namespace SectorMS.models;

public class Sector
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Student> Students { get; set; }
    public Sector() { }
 
}