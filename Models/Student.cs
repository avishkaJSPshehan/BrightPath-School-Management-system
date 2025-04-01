using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementsystem.Models;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public int Grade { get; set; }
    [Required]
    public string? Description { get; set; }
}
