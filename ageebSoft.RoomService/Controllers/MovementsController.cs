using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ageebSoft.RoomService.Data;
using ageebSoft.RoomService.Models;

namespace ageebSoft.RoomService.Controllers
{
    public class MovementsController : Controller
    {
        private readonly MyDB _context;

        public MovementsController(MyDB context)
        {
            _context = context;
        }

        // GET: Movements
        public async Task<IActionResult> Index()
        {
            var myDB = _context.Movements.Include(r => r.Cust);
            return View(await myDB.ToListAsync());
        }

        // GET: Movements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsMovement = await _context.Movements
                .Include(r => r.Cust)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomsMovement == null)
            {
                return NotFound();
            }

            return View(roomsMovement);
        }

        // GET: Movements/Create
        public IActionResult Create()
        {
            ViewData["CustId"] = new SelectList(_context.Custs, "Id", "Id");
            return View();
        }

        // POST: Movements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustId,RoomId,Id,Note")] RoomsMovement roomsMovement)
        {
            if (ModelState.IsValid)
            {
                roomsMovement.Id = Guid.NewGuid();
                _context.Add(roomsMovement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustId"] = new SelectList(_context.Custs, "Id", "Id", roomsMovement.CustId);
            return View(roomsMovement);
        }

        // GET: Movements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsMovement = await _context.Movements.FindAsync(id);
            if (roomsMovement == null)
            {
                return NotFound();
            }
            ViewData["CustId"] = new SelectList(_context.Custs, "Id", "Id", roomsMovement.CustId);
            return View(roomsMovement);
        }

        // POST: Movements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CustId,RoomId,Id,Note")] RoomsMovement roomsMovement)
        {
            if (id != roomsMovement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomsMovement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomsMovementExists(roomsMovement.Id))
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
            ViewData["CustId"] = new SelectList(_context.Custs, "Id", "Id", roomsMovement.CustId);
            return View(roomsMovement);
        }

        // GET: Movements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomsMovement = await _context.Movements
                .Include(r => r.Cust)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roomsMovement == null)
            {
                return NotFound();
            }

            return View(roomsMovement);
        }

        // POST: Movements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var roomsMovement = await _context.Movements.FindAsync(id);
            _context.Movements.Remove(roomsMovement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomsMovementExists(Guid id)
        {
            return _context.Movements.Any(e => e.Id == id);
        }
    }
}
