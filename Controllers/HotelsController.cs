using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelListing.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Hotel 1", Address = "Address 1", Rating = 4.5 },
            new Hotel { Id = 2, Name = "Hotel 2", Address = "Address 2", Rating = 4.0 },
            new Hotel { Id = 3, Name = "Hotel 3", Address = "Address 3", Rating = 3.5 }
        };

        // GET: api/hotels
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get() 
        {
            return Ok(hotels);
        }

        // GET: api/hotels/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }
    
            return Ok(hotel);
        }

        // POST: api/hotels
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if(hotels.Any(h => h.Id == newHotel.Id))
            {
                return BadRequest("A hotel with the same ID already exists.");
            }

            hotels.Add(newHotel);
            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
        }

        // PUT: api/hotels/5
        [HttpPut("{id}")]
        public ActionResult<Hotel> Put(int id, [FromBody] Hotel value)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

           hotel.Name = value.Name;
            hotel.Address = value.Address;
            hotel.Rating = value.Rating;
            return NoContent();
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public ActionResult<Hotel> Delete(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if(hotel == null)
            {
                return NotFound(new { message = $"Hotel with ID {id} not found." });
            }

            hotels.Remove(hotel);
            return NoContent();
        }
    }
}