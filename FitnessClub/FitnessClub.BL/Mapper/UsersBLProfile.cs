using AutoMapper;
using FitnessClub.FitnessClub.BL.Users.Entity;
using FitnessClub.FitnessClub.DataAccess.Entities;

namespace FitnessClub.FitnessClub.BL.Mapper
{
    public class UsersBLProfile : Profile
    {
        public UsersBLProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                // добавить Club и Role
                // .ForMember(dest => dest.Club, opt => opt.MapFrom(src => src.Club))
                // .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                //время отредачить
                .ReverseMap();

            CreateMap<CreateUser, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID обычно генерируется автоматически
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
                // добавить Club и Role
                // .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
                // .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId));

            CreateMap<UpdateUser, UserEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Patronymic, opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                // добавить Club и Role
                // .ForMember(dest => dest.ClubId, opt => opt.MapFrom(src => src.ClubId))
                // .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.ModificationTime, opt => opt.Ignore()); // игнорировать дату модификации
        }
    }
}
