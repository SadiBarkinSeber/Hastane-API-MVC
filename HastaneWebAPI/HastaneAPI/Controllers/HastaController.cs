using HastaneAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HastaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        public HastaController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<HastaListDTO>> GetAll()
        {
            var hastaList = await dbContext.Hastalar.ToListAsync();
            List<HastaListDTO> hastaListDTOs = new List<HastaListDTO>();
            foreach (var hasta in hastaList)
            {
                Hastane hastane = await dbContext.Hastaneler.FindAsync(hasta.HastaneId);
                HastaListDTO hastaListDTO = new HastaListDTO()
                {
                    Adi = hasta.Adi,
                    Soyadi = hasta.Soyadi,
                    Klinik = hasta.Klinik,
                    HastaneAdi = hastane.HastaneAdi
                };
                hastaListDTOs.Add(hastaListDTO);
            }
            return hastaListDTOs;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hasta = await dbContext.Hastalar.FirstOrDefaultAsync(m => m.Id == id);
            if (hasta == null)
                return NotFound();
            return Ok(hasta);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHasta(HastaDTO hastaDTO)
        {
            var hasta = new Hasta()
            {
                Adi = hastaDTO.Adi,
                Soyadi = hastaDTO.Soyadi,
                Klinik = hastaDTO.Klinik,
                HastaneId = hastaDTO.HastaneId
            };

            dbContext.Hastalar.Add(hasta);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHasta(int id, HastaDTO hastaDTO)
        {
            var hasta = await dbContext.Hastalar.FindAsync(id);

            if (hasta == null)
            {
                return NotFound();
            }

            hasta.Adi = hastaDTO.Adi;
            hasta.Soyadi = hastaDTO.Soyadi;
            hasta.Klinik = hastaDTO.Klinik;
            hasta.HastaneId = hastaDTO.HastaneId;

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHasta(int id)
        {
            var hasta = await dbContext.Hastalar.FindAsync(id);

            if (hasta == null)
            {
                return NotFound();
            }

            dbContext.Hastalar.Remove(hasta);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

    }
}
