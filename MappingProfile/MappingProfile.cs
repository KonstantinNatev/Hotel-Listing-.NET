using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            .ForMember(dest => dest.CountryName, opt => opt.MapFrom<CountryNameResolver>());
        CreateMap<CreateHotelDto, Hotel>();

        CreateMap<Hotel, GetHotelsSlimDto>();
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