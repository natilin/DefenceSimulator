using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefenceSimulator.Data;
using DefenceSimulator.Models;

namespace DefenceSimulator.Controllers
{
    public class SalvoesController : Controller
    {
        private readonly DefenceSimulatorContext _context;

        public SalvoesController(DefenceSimulatorContext context)
        {
            _context = context;
        }

        // GET: Salvoes
        public async Task<IActionResult> Index()
        {
            var defenceSimulatorContext = _context.Salvo.Include(s => s.Enemy).Include(s => s.Weapon);
            return View(await defenceSimulatorContext.ToListAsync());
        }
        //[HttpPut]
        // Put: Salvoes/Details/5
        public async Task<IActionResult> Launch(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salvo = await _context.Salvo.FindAsync(id);
            try
            {
                salvo.IsActive = true;
                salvo.LaunchTime = DateTime.Now;
                _context.Update(salvo);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalvoExists(salvo.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
                return RedirectToAction(nameof(Index)); ;
        }

        // GET: Salvoes/Create
        public IActionResult Create()
        {
            ViewData["EnemyId"] = new SelectList(_context.Enemy, "Id", "Name");
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "WeaponId", "Name");
            return View();
        }

        // POST: Salvoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnemyId,LaunchTime,WeaponId,WeaponAmount,IsActive")] Salvo salvo)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(salvo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnemyId"] = new SelectList(_context.Enemy, "Id", "Name", salvo.EnemyId);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "WeaponId", "Name", salvo.WeaponId);
            return View(salvo);
        }

        // GET: Salvoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salvo = await _context.Salvo.FindAsync(id);
            if (salvo == null)
            {
                return NotFound();
            }
            ViewData["EnemyId"] = new SelectList(_context.Enemy, "Id", "Name", salvo.EnemyId);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "WeaponId", "Name", salvo.WeaponId);
            return View(salvo);
        }

        // POST: Salvoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnemyId,LaunchTime,WeaponId,WeaponAmount,IsActive")] Salvo salvo)
        {
            if (id != salvo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salvo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalvoExists(salvo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnemyId"] = new SelectList(_context.Enemy, "Id", "Name", salvo.EnemyId);
            ViewData["WeaponId"] = new SelectList(_context.Weapon, "WeaponId", "Name", salvo.WeaponId);
            return View(salvo);
        }

        // GET: Salvoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salvo = await _context.Salvo
                .Include(s => s.Enemy)
                .Include(s => s.Weapon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salvo == null)
            {
                return NotFound();
            }

            return View(salvo);
        }

        // POST: Salvoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salvo = await _context.Salvo.FindAsync(id);
            if (salvo != null)
            {
                _context.Salvo.Remove(salvo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalvoExists(int id)
        {
            return _context.Salvo.Any(e => e.Id == id);
        }
    }
}
