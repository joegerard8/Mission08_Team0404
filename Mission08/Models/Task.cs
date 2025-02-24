namespace Mission08.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Task
{
    public int Id { get; set; } // Primary Key

    [Required(ErrorMessage = "Task name is required.")]
    public string Name { get; set; } // Task (Required)

    [DataType(DataType.Date)]
    public DateTime? DueDate { get; set; } // Due Date (Optional)

    [Required(ErrorMessage = "Quadrant is required.")]
    public int Quadrant { get; set; } // Quadrant (Required)

    [Required(ErrorMessage = "Category is required.")]
    public int CategoryId { get; set; } // Foreign Key

    [ForeignKey("CategoryId")]
    public Category Category { get; set; } // Navigation Property

    public bool Completed { get; set; } = false; // Completed (True/False)
}