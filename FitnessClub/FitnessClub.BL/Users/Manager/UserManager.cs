using AutoMapper;
using FitnessClub.FitnessClub.BL.Users.Entity;
using FitnessClub.FitnessClub.DataAccess.Entities;
using FitnessClub.FitnessClub.DataAccess.Repository;
using System;

namespace FitnessClub.FitnessClub.BL.Users.Manager
{
    public class UsersManager : IUserManager
    {
        private readonly IRepository<UserEntity> _usersRepository;
        private readonly IMapper _mapper;

        public UsersManager(IRepository<UserEntity> usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public UserModel CreateUser(CreateUser createModel)
        {
            if (string.IsNullOrEmpty(createModel.Email) || string.IsNullOrEmpty(createModel.PasswordHash))
            {
                throw new ArgumentException("Email and PasswordHash are required.");
            }

            UserEntity entity = _mapper.Map<UserEntity>(createModel);
            
            entity = _usersRepository.Save(entity);
            return _mapper.Map<UserModel>(entity);
        }

        public void DeleteUser(int id)
        {
            var entity = _usersRepository.GetById(id);
            if (entity == null)
            {
                throw new ExeptionNotFound($"User with ID {id} not found.");
            }
            
            _usersRepository.Delete(entity);
        }

        public UserModel UpdateUser(UserModel updateModel)
        {
            if (updateModel.Id <= 0)
            {
                throw new ArgumentException("Invalid user ID.");
            }

            UserEntity entity = _mapper.Map<UserEntity>(updateModel);
            
            entity = _usersRepository.Save(entity);
            return _mapper.Map<UserModel>(entity);
        }
        
        public UserModel Login(LoginUser loginUser)
        {
            if (string.IsNullOrEmpty(loginUser.PasswordHash))
            {
                throw new ArgumentException("Password must be provided.");
            }

            UserEntity userEntity = null;

            if (!string.IsNullOrEmpty(loginUser.Email))
            {
                userEntity = _usersRepository.GetAll().FirstOrDefault(u => u.Email == loginUser.Email);
            }
            else if (loginUser.Id.HasValue)
            {
                userEntity = _usersRepository.GetById(loginUser.Id.Value);
            }

            if (userEntity == null)
            {
                throw new ExeptionNotFound($"User not found.");
            }

            

            return _mapper.Map<UserModel>(userEntity);
        }

        
        public void Logout(int userId)
        {
            var userEntity = _usersRepository.GetById(userId);
            if (userEntity == null)
            {
                throw new ExeptionNotFound($"User with ID {userId} not found.");
            }

            //че-то сюда еще
        }
    }
}