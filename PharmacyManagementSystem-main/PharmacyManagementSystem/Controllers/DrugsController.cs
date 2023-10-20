using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {
        private readonly PharmacyManagementSystemContext _context;

        public DrugsController(PharmacyManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/Drugs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> GetDrug()
        {
          if (_context.Drug == null)
          {
              return NotFound();
          }
            return await _context.Drug.ToListAsync();
        }

        // GET: api/Drugs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> GetDrug(int id)
        {
          if (_context.Drug == null)
          {
              return NotFound();
          }
            var drug = await _context.Drug.FindAsync(id);

            if (drug == null)
            {
                return NotFound();
            }

            return drug;
        }

        // PUT: api/Drugs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrug(int id, Drug drug)
        {
            if (id != drug.drug_id)
            {
                return BadRequest();
            }

            _context.Entry(drug).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrugExists(id))
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

        // POST: api/Drugs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Drug>> PostDrug(Drug drug)
        {
          if (_context.Drug == null)
          {
              return Problem("Entity set 'PharmacyManagementSystemContext.Drug'  is null.");
          }
            _context.Drug.Add(drug);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrug", new { id = drug.drug_id }, drug);
        }

        // DELETE: api/Drugs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrug(int id)
        {
            if (_context.Drug == null)
            {
                return NotFound();
            }
            var drug = await _context.Drug.FindAsync(id);
            if (drug == null)
            {
                return NotFound();
            }

            _context.Drug.Remove(drug);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrugExists(int id)
        {
            return (_context.Drug?.Any(e => e.drug_id == id)).GetValueOrDefault();
        }
    }
}
