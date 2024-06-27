using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonthlyBudgetStatisticsController : ControllerBase
    {
        private readonly WalletGuardianDbContext _context;

        public MonthlyBudgetStatisticsController(WalletGuardianDbContext context)
        {
            _context = context;
        }

        // GET: api/MonthlyBudgetStatistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonthlyBudgetStatistic>>> GetMonthlyBudgetStatistics()
        {
            return await _context.MonthlyBudgetStatistics.ToListAsync();
        }

        // GET: api/MonthlyBudgetStatistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonthlyBudgetStatistic>> GetMonthlyBudgetStatistic(int id)
        {
            var monthlyBudgetStatistic = await _context.MonthlyBudgetStatistics.FindAsync(id);

            if (monthlyBudgetStatistic == null)
            {
                return NotFound();
            }

            return monthlyBudgetStatistic;
        }

        // PUT: api/MonthlyBudgetStatistics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthlyBudgetStatistic(int id, MonthlyBudgetStatistic monthlyBudgetStatistic)
        {
            if (id != monthlyBudgetStatistic.Id)
            {
                return BadRequest();
            }

            _context.Entry(monthlyBudgetStatistic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyBudgetStatisticExists(id))
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

        // POST: api/MonthlyBudgetStatistics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonthlyBudgetStatistic>> PostMonthlyBudgetStatistic(MonthlyBudgetStatistic monthlyBudgetStatistic)
        {
            _context.MonthlyBudgetStatistics.Add(monthlyBudgetStatistic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthlyBudgetStatistic", new { id = monthlyBudgetStatistic.Id }, monthlyBudgetStatistic);
        }

        // DELETE: api/MonthlyBudgetStatistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthlyBudgetStatistic(int id)
        {
            var monthlyBudgetStatistic = await _context.MonthlyBudgetStatistics.FindAsync(id);
            if (monthlyBudgetStatistic == null)
            {
                return NotFound();
            }

            _context.MonthlyBudgetStatistics.Remove(monthlyBudgetStatistic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonthlyBudgetStatisticExists(int id)
        {
            return _context.MonthlyBudgetStatistics.Any(e => e.Id == id);
        }
    }
}
