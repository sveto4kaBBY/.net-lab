using System.ComponentModel.DataAnnotations.Schema;
namespace FitnessClub.FitnessClub.DataAccess.Entities;

[Table("roles")]
public class RoleEntity
{
    public int Id { get; set; }
    
    public string RoleValue { get; set; }
    
    public List<UserEntity> Users { get; set; }
}