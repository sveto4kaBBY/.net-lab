using AutoMapper;
using FitnessClub.FitnessClub.BL.Users.Entity;
using FitnessClub.FitnessClub.DataAccess.Entities;
using FitnessClub.FitnessClub.DataAccess.Repository;
using System.Linq;

namespace FitnessClub.FitnessClub.BL.Users.Provider
{
    public class UsersProvider : IUserProvider
    {
        private readonly IRepository<UserEntity> _usersRepository;
        private readonly IMapper _mapper;

        public UsersProvider(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserModel> GetUsers(FilterUser filter)
        {
            var query = _usersRepository.GetAll();

            // Фильтрация по роли потом добавить
            

            
            if (!string.IsNullOrEmpty(filter.NamePart))
            {
                query = query.Where(u => u.Name.Contains(filter.NamePart));
            }

            
            if (!string.IsNullOrEmpty(filter.EmailPart))
            {
                query = query.Where(u => u.Email.Contains(filter.EmailPart));
            }

            
            return query.Select(u => _mapper.Map<UserModel>(u)).ToList();
        }

        public UserModel GetUserInfo(int id)
        {
            var entity = _usersRepository.GetById(id);
            if (entity == null)
            {
                throw new ExeptionNotFound($"User with ID {id} not found.");
            }
            return _mapper.Map<UserModel>(entity);
        }
    }
}