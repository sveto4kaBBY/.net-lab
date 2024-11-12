using FitnessClub.FitnessClub.BL.Users.Entity;

namespace FitnessClub.FitnessClub.BL.Users.Provider;

public interface IUserProvider
{
    IEnumerable<UserModel> GetUsers(FilterUser filter = null);
    UserModel GetUserInfo(int id);
}