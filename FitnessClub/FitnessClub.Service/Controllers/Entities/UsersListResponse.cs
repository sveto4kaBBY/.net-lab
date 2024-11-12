using FitnessClub.FitnessClub.BL.Users.Entity;
using FitnessClub.FitnessClub.DataAccess.Entities;

namespace FitnessClub.FitnessClub.Service.Controllers.Entities
{
    public class UsersListResponse
    {
        public List<UserModel> Users { get; set; }
    }
}