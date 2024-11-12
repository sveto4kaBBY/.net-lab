namespace FitnessClub.FitnessClub.BL.Users.Entity;

public class LoginUser
{
    
    public int? Id { get; set; }
    
    public string? Email { get; set; }
    
    public string PasswordHash { get; set; }
}