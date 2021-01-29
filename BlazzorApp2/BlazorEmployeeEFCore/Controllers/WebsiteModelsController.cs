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
    public class WebsiteModelsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public WebsiteModelsController(SqlDbContext context)
        {
            _context = context;
        }

        // GET: api/WebsiteModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebsiteModel>>> GetWebsiteModels()
        {
            return await _context.WebsiteModels.ToListAsync();
        }

        // GET: api/WebsiteModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WebsiteModel>> GetWebsiteModel(int id)
        {
            var websiteModel = await _context.WebsiteModels.FindAsync(id);

            if (websiteModel == null)
            {
                return NotFound();
            }

            return websiteModel;
        }

        // PUT: api/WebsiteModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWebsiteModel(int id, WebsiteModel websiteModel)
        {
            if (id != websiteModel.id)
            {
                return BadRequest();
            }

            _context.Entry(websiteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WebsiteModelExists(id))
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

        // POST: api/WebsiteModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WebsiteModel>> PostWebsiteModel(WebsiteModel websiteModel)
        {
            _context.WebsiteModels.Add(websiteModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWebsiteModel", new { id = websiteModel.id }, websiteModel);
        }

        // DELETE: api/WebsiteModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WebsiteModel>> DeleteWebsiteModel(int id)
        {
            var websiteModel = await _context.WebsiteModels.FindAsync(id);
            if (websiteModel == null)
            {
                return NotFound();
            }

            _context.WebsiteModels.Remove(websiteModel);
            await _context.SaveChangesAsync();

            return websiteModel;
        }

        private bool WebsiteModelExists(int id)
        {
            return _context.WebsiteModels.Any(e => e.id == id);
        }
    }
}
