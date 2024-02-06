using HastaneAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public HastaneController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Hastane>> GetAll()
        {
            return await dbContext.Hastaneler.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hastane = await dbContext.Hastaneler.FirstOrDefaultAsync(m => m.Id == id);
            if (hastane == null)
                return NotFound();
            return Ok(hastane);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHastane(HastaneDTO hastaneDTO)
        {
            var hastane = new Hastane()
            {
                HastaneAdi = hastaneDTO.HastaneAdi,
                Adres = hastaneDTO.Adres,
            };

            dbContext.Hastaneler.Add(hastane);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHastane(int id, HastaneDTO hastaneDTO)
        {
            var hastane = await dbContext.Hastaneler.FindAsync(id);

            if (hastane == null)
            {
                return NotFound();
            }

            hastane.HastaneAdi = hastaneDTO.HastaneAdi;
            hastane.Adres = hastaneDTO.Adres;

            await dbContext.SaveChangesAsync();
           

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHastane(int id)
        {
            var hastane = await dbContext.Hastaneler.FindAsync(id);

            if (hastane == null)
            {
                return NotFound();
            }

            dbContext.Hastaneler.Remove(hastane);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
