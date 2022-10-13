using AutoMapper;

namespace AutoMapperWebAPI.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		//CreateMap<MAPFRA,MAPTIL>();
		CreateMap<Entities.User, DTO.UserDTO>();
		CreateMap<DTO.UserDTO, Entities.User>();
        CreateMap<DTO.CreateUserDTO, Entities.User>()
			.ForMember(dest =>
				dest.FirstName,
				opt => opt.MapFrom(src => src.FName))
			.ForMember(dest =>
				dest.LastName,
				opt => opt.MapFrom(src => src.LName));
    }
}
