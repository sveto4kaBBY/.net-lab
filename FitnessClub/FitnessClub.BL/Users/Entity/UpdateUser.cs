namespace FitnessClub.FitnessClub.BL.Users.Entity;

public class UpdateUser
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string PasswordHash { get; set; }
    
    public string Surname { get; set; }
    
    public string Patronymic { get; set; }
    
    public DateTime Birthday { get; set; }
    
    public string Email { get; set; }
    
    // public int ClubId { get; set; } потом исправить
    
    // public int RoleId { get; set; } потом исправить
}