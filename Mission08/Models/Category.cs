namespace Mission08.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public int Id { get; set; } // Primary Key

    [Required(ErrorMessage = "Category name is required.")]
    public string Name { get; set; } // Category Name (Home, School, Work, Church)

    public List<Task> Tasks { get; set; } // Navigation Property
}