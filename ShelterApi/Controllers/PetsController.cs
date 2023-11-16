using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShelterApi.Models;

namespace ShelterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly ShelterApiContext _db;

        public PetsController(ShelterApiContext db)
        {
        _db = db;
        }

        // GET api/pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> Get(string species, string name)
        {
            IQueryable<Pet> query = _db.Pets.AsQueryable();

            if (species != null)
            {
                query = query.Where(entry => entry.Species == species);
            }

            if (name != null)
            {
                query = query.Where(entry => entry.Name == name);
            }


        return await query.ToListAsync();
        }

        // GET: api/Pets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
        Pet pet = await _db.Pets.FindAsync(id);

        if (pet == null)
        {
            return NotFound();
        }

        return pet;
        }

        // POST api/pets
        [HttpPost]
        public async Task<ActionResult<Pet>> Post(Pet pet)
        {
        _db.Pets.Add(pet);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPet), new { id = pet.PetId }, pet);
        }

        // PUT: api/Pets/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pet pet)
        {
        if (id != pet.PetId)
        {
            return BadRequest();
        }

        _db.Pets.Update(pet);

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PetExists(id))
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

        private bool PetExists(int id)
        {
        return _db.Pets.Any(e => e.PetId == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
        Pet pet = await _db.Pets.FindAsync(id);
        if (pet == null)
        {
            return NotFound();
        }

        _db.Pets.Remove(pet);
        await _db.SaveChangesAsync();

        return NoContent();
        }
    }
}