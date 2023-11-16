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
        public async Task<ActionResult<IEnumerable<Pet>>> Get()
        {
        return await _db.Pets.ToListAsync();
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
    }
}