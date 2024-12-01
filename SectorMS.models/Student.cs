﻿namespace SectorMS.models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; } 
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public string BirthPlace { get; set; }
    public int SectorId { get; set; } // the foreign key sector id
    
    //l'ajoutant un ? après le type, pour lui permettre d'accepeter les valeurs null
    public Sector? Sector { get; set; }
    
}