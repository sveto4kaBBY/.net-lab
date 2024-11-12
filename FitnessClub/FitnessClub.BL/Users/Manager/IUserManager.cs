using FitnessClub.FitnessClub.BL.Users.Entity;

namespace FitnessClub.FitnessClub.BL.Users.Manager;

public interface IUserManager
{
    UserModel CreateUser(CreateUser createModel);
    void DeleteUser(int id);
    UserModel UpdateUser(UserModel updateModel);
    void Logout(int userId);
    
    UserModel Login(LoginUser loginModel);
}