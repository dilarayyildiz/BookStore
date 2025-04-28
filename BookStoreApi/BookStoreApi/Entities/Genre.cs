using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApi.Entities;

public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    
}