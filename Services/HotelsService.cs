using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelListing.api.Results;
using HotelListing.Api.Constants;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using HotelListing.Api.DTO.Hotel;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Services;

public class HotelsService(HotelListingDbContext context, IMapper mapper) : IHotelsService
{
    public async Task<Result<IEnumerable<GetHotelsDto>>> GetHotelsAsync()
    {
        var hotels = await context.Hotels
            .ProjectTo<GetHotelsDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return Result<IEnumerable<GetHotelsDto>>.Success(hotels);
    }

    public async Task<Result<GetHotelDto?>> GetHotelAsync(int id)
    {
        var hotel = await context.Hotels
        .Where(h => h.Id == id)
        .ProjectTo<GetHotelDto>(mapper.ConfigurationProvider)
        .FirstOrDefaultAsync();

        return hotel is null
            ? Result<GetHotelDto?>.NotFound(new Error(ErrorCodes.NotFound, $"Hotel with ID {id} was not found."))
            : Result<GetHotelDto?>.Success(hotel);
    }

    public async Task<Result<GetHotelDto>> CreateHotelAsync(CreateHotelDto hotelDto)
    {
        try
        {
            var existingHotel = await HotelNameExistsAsync(hotelDto.Name);
            if (existingHotel)
            {
                return Result<GetHotelDto>.Failure(new Error(ErrorCodes.Conflict, $"Hotel with name '{hotelDto.Name}' already exists."));
            }

            var hotel = mapper.Map<Hotel>(hotelDto);
            context.Hotels.Add(hotel);
            await context.SaveChangesAsync();

            var createdHotel = await context.Hotels
                .Where(h => h.Id == hotel.Id)
                .ProjectTo<GetHotelDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return Result<GetHotelDto>.Success(createdHotel);
        }
        catch (System.Exception)
        {
            return Result<GetHotelDto>.Failure();
        }
    }

    public async Task<Result> UpdateHotelAsync(int id, UpdateHotelDto hotelDto)
    {
        try
        {
            if (id != hotelDto.Id)
            {
                return Result.BadRequest(new Error(ErrorCodes.Validation, "Hotel ID mismatch."));
            }

            var hotel = await context.Hotels.FindAsync(id);
            if (hotel is null)
            {
                return Result.NotFound(new Error(ErrorCodes.NotFound, $"Hotel with ID {id} not found."));
            }

            // Automatically cast the incomming data in the hotel            
            mapper.Map(hotelDto, hotel);

            context.Entry(hotel).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Result.Success();
        }
        catch (System.Exception)
        {
            return Result.Failure(new Error(ErrorCodes.Failure, "An error occurred while updating the hotel."));
        }
    }

    public async Task<Result> DeleteHotelAsync(int id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel is null)
        {
            return Result.NotFound(new Error(ErrorCodes.NotFound, $"Hotel with ID {id} not found."));
        }

        context.Hotels.Remove(hotel);
        await context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<bool> HotelExistsAsync(int id)
    {
        return await context.Hotels.AnyAsync(c => c.Id == id);
    }

    public async Task<bool> HotelNameExistsAsync(string name)
    {
        return await context.Hotels.AnyAsync(c => c.Name == name);
    }
}
