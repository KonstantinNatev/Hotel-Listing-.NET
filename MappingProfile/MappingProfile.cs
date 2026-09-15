using HotelListing.Api.DTO.Hotel;
using HotelListing.Api.Data;
using AutoMapper;
using HotelListing.Api.DTO.Country;

namespace HotelListing.Api.MappingProfile;

public class HotelMappingProfile : Profile
{
    public HotelMappingProfile()
    {
        CreateMap<Hotel, GetHotelDto>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country!.Name));

        CreateMap<Hotel, GetHotelsDto>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country!.Name));

        CreateMap<Hotel, GetHotelsSlimDto>();

        CreateMap<CreateHotelDto, Hotel>();
        CreateMap<UpdateHotelDto, Hotel>();
    }
}

public class CountryMappingProfile : Profile
{
    public CountryMappingProfile()
    {
        CreateMap<Country, GetCountryDto>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.CountryId));

        CreateMap<Country, GetCountriesDto>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.CountryId));

        CreateMap<CreateCountryDto, Country>();

        CreateMap<UpdateCountryDto, Country>();
    }
}

public class CountryNameResolver : IValueResolver<Hotel, GetHotelDto, string>
{
    public string Resolve(Hotel source, GetHotelDto destination, string destMember, ResolutionContext context)
    {
        return source.Country?.Name ?? string.Empty;
    }
}