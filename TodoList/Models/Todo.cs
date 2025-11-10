using System.ComponentModel.DataAnnotations;

namespace TodoList.Models;

public class Todo
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public bool IsCompleted { get; set; }
}