using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClub.FitnessClub.DataAccess.Entities;

[Table("users")]
public class UserEntity: BaseEntity
{
    public string Name { get; set; }
    
    public int PasswordHash { get; set; }
    
    public string Surname { get; set; }
    
    public string Patronymic { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public string Email { get; set; }
    
    public int ClubId { get; set; }
    
    [ForeignKey("RoleId")]
    public int RoleId { get; set; }
    
    public RoleEntity Role { get; set; }
    
    public ICollection<TrainingEntity> Trainings { get; set; }
}