using System.ComponentModel.DataAnnotations.Schema;
namespace FitnessClub.FitnessClub.DataAccess.Entities;

[Table("training")]
public class TrainingEntity :BaseEntity
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int Cost { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public ICollection<UserEntity> Users { get; set; }
}