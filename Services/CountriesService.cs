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
using HotelListing.api.Results;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using HotelListing.Api.Constants;

namespace HotelListing.Api.Services;

public class CountriesService(HotelListingDbContext context, IMapper mapper) : ICountriesService
{
    public async Task<Result<IEnumerable<GetCountriesDto>>> GetCountriesAsync()
    {
        var countries = await context.Countries
            .ProjectTo<GetCountriesDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Result<IEnumerable<GetCountriesDto>>.Success(countries);
    }

    public async Task<Result<GetCountryDto?>> GetCountryAsync(int id)
    {
        var country = await context.Countries
            .Where(c => c.CountryId == id)
            .ProjectTo<GetCountryDto>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

        return country is null
            ? Result<GetCountryDto?>.NotFound(new Error(ErrorCodes.NotFound, $"Country with ID {id} was not found."))
            : Result<GetCountryDto?>.Success(country);
    }


    public async Task<Result<GetCountryDto>> CreateCountryAsync(CreateCountryDto countryDto)
    {
        try
        {
            var existingCountry = await CountryNameExistsAsync(countryDto.Name);
            if (existingCountry)
            {
                return Result<GetCountryDto>.Failure(new Error(ErrorCodes.Conflict, $"Country with name '{countryDto.Name}' already exists."));
            }

            var country = mapper.Map<Country>(countryDto);

            context.Countries.Add(country);
            await context.SaveChangesAsync();

            var result = mapper.Map<GetCountryDto>(country);

            return Result<GetCountryDto>.Success(result);
        }
        catch (System.Exception)
        {
            return Result<GetCountryDto>.Failure();
        }
    }

    public async Task<Result> UpdateCountryAsync(int id, UpdateCountryDto countryDto)
    {
        try
        {
            if (id != countryDto.Id)
            {
                return Result.BadRequest(new Error(ErrorCodes.Validation, "Country ID mismatch."));
            }

            var country = await context.Countries.FindAsync(id);

            if (country is null)
            {
                return Result.NotFound(new Error(ErrorCodes.NotFound, $"Country with ID {id} not found."));
            }

            var duplicateCountry = await CountryNameExistsAsync(countryDto.Name);
            if (duplicateCountry)
            {
                return Result.Failure(new Error(ErrorCodes.Conflict, $"Country with name '{countryDto.Name}' already exists."));
            }

            mapper.Map(countryDto, country);

            context.Entry(country).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return Result.Success();
        }
        catch (System.Exception)
        {
            return Result.Failure(new Error(ErrorCodes.Failure, "An error occurred while updating the country."));
        }
    }

    public async Task<Result> DeleteCountryAsync(int id)
    {
        try
        {
            var country = await context.Countries.FindAsync(id);
            if (country is null)
            {
                return Result.NotFound(new Error(ErrorCodes.NotFound, $"Country with ID {id} not found."));
            }

            context.Countries.Remove(country);
            await context.SaveChangesAsync();

            return Result.Success();
        }
        catch (System.Exception)
        {
            return Result.Failure(new Error(ErrorCodes.Failure, "An error occurred while deleting the country."));
        }
    }


    public async Task<bool> CountryExistsAsync(int id)
    {
        return await context.Countries.AnyAsync(c => c.CountryId == id);
    }
    public async Task<bool> CountryNameExistsAsync(string name)
    {
        return await context.Countries.AnyAsync(c => c.Name.ToLower().Trim() == name.ToLower().Trim());
    }
}