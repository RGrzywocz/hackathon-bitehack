using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorEmployeeEFCore.Data;
using BlazorEmployeeEFCore.Shared;

namespace BlazorEmployeeEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceModelsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public PlaceModelsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/PlaceModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaceModel>>> GetPlaceModels()
        {
            return await _context.PlaceModels.ToListAsync();
        }

        // GET: api/PlaceModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaceModel>> GetPlaceModel(int id)
        {
            var placeModel = await _context.PlaceModels.FindAsync(id);

            if (placeModel == null)
            {
                return NotFound();
            }

            return placeModel;
        }

        // PUT: api/PlaceModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaceModel(int id, PlaceModel placeModel)
        {
            if (id != placeModel.id)
            {
                return BadRequest();
            }

            _context.Entry(placeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlaceModelExists(id))
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

        // POST: api/PlaceModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] PlaceModel placeModel)
        {
            _context.PlaceModels.AddAsync(placeModel);
             _context.SaveChanges();

           return CreatedAtAction("GetPlaceModel", new { id = placeModel.id }, placeModel);
        //    return Respons
        }

        // DELETE: api/PlaceModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlaceModel>> DeletePlaceModel(int id)
        {
            var placeModel = await _context.PlaceModels.FindAsync(id);
            if (placeModel == null)
            {
                return NotFound();
            }

            _context.PlaceModels.Remove(placeModel);
            await _context.SaveChangesAsync();

            return placeModel;
        }

        private bool PlaceModelExists(int id)
        {
            return _context.PlaceModels.Any(e => e.id == id);
        }
    }
}
