using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIHCEmployeeAPI.Models;

namespace UIHCEmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReceiptsController : ControllerBase
    {
        private readonly EmployeeReceiptUploadContext _context;

        public EmployeeReceiptsController(EmployeeReceiptUploadContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeReceipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReceipt>>> GetEmployeeReceipt()
        {
            return await _context.EmployeeReceipt.ToListAsync();
        }

        // GET: api/EmployeeReceipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeReceipt>> GetEmployeeReceipt(int id)
        {
            var EmployeeReceipt = await _context.EmployeeReceipt.FindAsync(id);

            if (EmployeeReceipt == null)
            {
                return NotFound();
            }

            return EmployeeReceipt;
        }

        // PUT: api/EmployeeReceipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeReceipt(int id, EmployeeReceipt EmployeeReceipt)
        {
            if (id != EmployeeReceipt.Id)
            {
                return BadRequest();
            }

            _context.Entry(EmployeeReceipt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeReceiptExists(id))
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

        // POST: api/EmployeeReceipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [RequestSizeLimit(bytes: 10_000_000)]
        public async Task<IActionResult> PostEmployeeReceipt ([FromForm]EmployeeReceipt EmployeeReceipt)
        {
            
            // write the uploaded file to a memory string to create a byte[] for database operation
            using (var memoryStream = new MemoryStream())
            {                
                await (EmployeeReceipt.ReceiptFile.CopyToAsync(memoryStream));
                
                EmployeeReceipt.Receipt = memoryStream.ToArray();
                EmployeeReceipt.ReceiptFileName = EmployeeReceipt.ReceiptFile.FileName;
               
                _context.EmployeeReceipt.Add(EmployeeReceipt);
                await _context.SaveChangesAsync();

                return Ok();
                //CreatedAtAction("GetEmployeeReceipt", new { id = EmployeeReceipt.Id }, EmployeeReceipt);
            }
        }

        // DELETE: api/EmployeeReceipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeReceipt(int id)
        {
            var EmployeeReceipt = await _context.EmployeeReceipt.FindAsync(id);
            if (EmployeeReceipt == null)
            {
                return NotFound();
            }

            _context.EmployeeReceipt.Remove(EmployeeReceipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeReceiptExists(int id)
        {
            return _context.EmployeeReceipt.Any(e => e.Id == id);
        }
    }
}
