using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using HotelListing.Api.DTO.Hotel;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Services;

public class HotelsService(HotelListingDbContext context) : IHotelsService
{
    public async Task<IEnumerable<GetHotelsDto>> GetHotelsAsync()
    {
        var hotels = await context.Hotels.Select(h => new GetHotelsDto(
            h.Id,
            h.Name,
            h.Address,
            h.Rating,
            h.CountryId
        )).ToListAsync();

        return hotels;
    }

    public async Task<GetHotelDto?> GetHotelAsync(int id)
    {
        var hotel = await context.Hotels
        .Select(h => new GetHotelDto(
            h.Id,
            h.Name,
            h.Address,
            h.Rating,
            h.Country!.Name
        ))
        .FirstOrDefaultAsync(h => h.Id == id);

        return hotel ?? null;
    }

    public async Task<GetHotelsDto> CreateHotelAsync(CreateHotelDto hotelDto)
    {
        var hotel = new Hotel
        {
            Name = hotelDto.Name,
            Address = hotelDto.Address,
            Rating = hotelDto.Rating,
            CountryId = hotelDto.CountryId
        };

        context.Hotels.Add(hotel);
        await context.SaveChangesAsync();

        var createdHotel = new GetHotelsDto(
            hotel.Id,
            hotel.Name,
            hotel.Address,
            hotel.Rating,
            hotel.CountryId);

        return createdHotel;
    }

    public async Task UpdateHotelAsync(int id, UpdateHotelDto hotelDto)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            throw new KeyNotFoundException($"Hotel with ID {id} not found.");
        }

        hotel.Name = hotelDto.Name;
        hotel.Address = hotelDto.Address;
        hotel.Rating = hotelDto.Rating;
        hotel.CountryId = hotelDto.CountryId;

        context.Entry(hotel).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteHotelAsync(int id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            throw new KeyNotFoundException($"Hotel with ID {id} not found.");
        }

        context.Hotels.Remove(hotel);
        await context.SaveChangesAsync();
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
