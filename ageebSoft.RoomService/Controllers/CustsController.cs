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
    public class CustsController : Controller
    {
        private readonly MyDB _context;

        public CustsController(MyDB context)
        {
            _context = context;
        }

        // GET: Custs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Custs.ToListAsync());
        }

        // GET: Custs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Custs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // GET: Custs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Custs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Tel,Address,Id,Note")] Cust cust)
        {
            if (ModelState.IsValid)
            {
                cust.Id = Guid.NewGuid();
                _context.Add(cust);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cust);
        }

        // GET: Custs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Custs.FindAsync(id);
            if (cust == null)
            {
                return NotFound();
            }
            return View(cust);
        }

        // POST: Custs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Tel,Address,Id,Note")] Cust cust)
        {
            if (id != cust.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cust);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustExists(cust.Id))
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
            return View(cust);
        }

        // GET: Custs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cust = await _context.Custs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cust == null)
            {
                return NotFound();
            }

            return View(cust);
        }

        // POST: Custs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cust = await _context.Custs.FindAsync(id);
            _context.Custs.Remove(cust);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustExists(Guid id)
        {
            return _context.Custs.Any(e => e.Id == id);
        }
    }
}
