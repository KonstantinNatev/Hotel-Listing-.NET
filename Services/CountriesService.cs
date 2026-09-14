using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HotelListing.Api.Data;
using Microsoft.AspNetCore.Mvc;
using HotelListing.Api.DTO.Country;
using HotelListing.Api.Contracts;
using HotelListing.Api.DTO.Hotel;

namespace HotelListing.Api.Services;

public class CountriesService(HotelListingDbContext context) : ICountriesService
{
    public async Task<IEnumerable<GetCountriesDto>> GetCountriesAsync()
    {
        var countries = await context.Countries
        .Select(c => new GetCountriesDto(
            c.CountryId,
            c.Name,
            c.ShortName
        )).ToListAsync();

        return countries;
    }

    public async Task<GetCountryDto?> GetCountryAsync(int id)
    {
        var country = await context.Countries
        .Where(c => c.CountryId == id)
        .Select(c => new GetCountryDto(
            c.CountryId,
            c.Name,
            c.ShortName,
            c.Hotels.Select(h => new GetHotelsSlimDto(
                h.Id,
                h.Name,
                h.Address,
                h.Rating
            )).ToList()
        ))
        .FirstOrDefaultAsync();

        return country ?? null;
    }


    public async Task<GetCountryDto> CreateCountryAsync(CreateCountryDto countryDto)
    {
        var country = new Country
        {
            Name = countryDto.Name,
            ShortName = countryDto.ShortName
        };

        context.Countries.Add(country);
        await context.SaveChangesAsync();

        var getCountryDto = new GetCountryDto(
            country.CountryId,
            country.Name,
            country.ShortName,
            new List<GetHotelsSlimDto>()
        );

        return getCountryDto;
    }

    public async Task UpdateCountryAsync(int id, UpdateCountryDto countryDto)
    {
        var country = await context.Countries.FindAsync(id) ?? throw new KeyNotFoundException($"Country with id {id} not found.");

        country.Name = countryDto.Name;
        country.ShortName = countryDto.ShortName;

        context.Entry(country).State = EntityState.Modified;

        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteCountryAsync(int id)
    {
        var country = await context.Countries.FindAsync(id);
        if (country == null)
        {
            return false;
        }

        context.Countries.Remove(country);
        await context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> CountryExistsAsync(int id)
    {
        return await context.Countries.AnyAsync(c => c.CountryId == id);
    }
    public async Task<bool> CountryNameExistsAsync(string name)
    {
        return await context.Countries.AnyAsync(c => c.Name == name);
    }

}