using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Api.Data;
using HotelListing.Api.DTO.Hotel;

namespace HotelListing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelsController(HotelListingDbContext context) : ControllerBase
{
    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetHotelsDto>>> GetHotels()
    {
        var hotels = await context.Hotels.Select(h => new GetHotelsDto(
            h.Id,
            h.Name,
            h.Address,
            h.Rating,
            h.CountryId
        )).ToListAsync();

        return Ok(hotels);
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetHotelDto>> GetHotel(int id)
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

        if (hotel == null)
        {
            return NotFound();
        }

        return Ok(hotel);
    }

    // PUT: api/Hotels/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHotel(int id, UpdateHotelDto hotelDto)
    {
        if (id != hotelDto.Id)
        {
            return BadRequest();
        }

        var hotel = await context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }

        hotel.Name = hotelDto.Name;
        hotel.Address = hotelDto.Address;
        hotel.Rating = hotelDto.Rating;
        hotel.CountryId = hotelDto.CountryId;

        context.Entry(hotel).State = EntityState.Modified;

        try
        {
            await context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Hotels
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto createHotelDto)
    {
        var hotel = new Hotel
        {
            Name = createHotelDto.Name,
            Address = createHotelDto.Address,
            Rating = createHotelDto.Rating,
            CountryId = createHotelDto.CountryId
        };

        context.Hotels.Add(hotel);
        await context.SaveChangesAsync();

        var hotelDto = new GetHotelsDto(
            hotel.Id,
            hotel.Name,
            hotel.Address,
            hotel.Rating,
            hotel.CountryId
        );

        return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotelDto);
    }

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var hotel = await context.Hotels.FindAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }

        context.Hotels.Remove(hotel);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private async Task<bool> HotelExists(int id)
    {
        return await context.Hotels.AnyAsync(e => e.Id == id);
    }
}
