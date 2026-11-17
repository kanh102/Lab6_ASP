using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab6_movie.Data;
using Lab6_movie.Models;

namespace Lab6_movie.Controllers
{
    public class MoviecsController : Controller
    {
        private readonly Lab6_movieContext _context;

        public MoviecsController(Lab6_movieContext context)
        {
            _context = context;
        }

        // GET: Moviecs
        public async Task<IActionResult> Index()
        {
            var lab6_movieContext = _context.Moviecs.Include(m => m.Genre);
            return View(await lab6_movieContext.ToListAsync());
        }

        // GET: Moviecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviecs = await _context.Moviecs
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviecs == null)
            {
                return NotFound();
            }

            return View(moviecs);
        }

        // GET: Moviecs/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id");
            return View();
        }

        // POST: Moviecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,GenreId")] Moviecs moviecs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moviecs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", moviecs.GenreId);
            return View(moviecs);
        }

        // GET: Moviecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviecs = await _context.Moviecs.FindAsync(id);
            if (moviecs == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", moviecs.GenreId);
            return View(moviecs);
        }

        // POST: Moviecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,GenreId")] Moviecs moviecs)
        {
            if (id != moviecs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moviecs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoviecsExists(moviecs.Id))
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
            ViewData["GenreId"] = new SelectList(_context.Genre, "Id", "Id", moviecs.GenreId);
            return View(moviecs);
        }

        // GET: Moviecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moviecs = await _context.Moviecs
                .Include(m => m.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moviecs == null)
            {
                return NotFound();
            }

            return View(moviecs);
        }

        // POST: Moviecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moviecs = await _context.Moviecs.FindAsync(id);
            if (moviecs != null)
            {
                _context.Moviecs.Remove(moviecs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoviecsExists(int id)
        {
            return _context.Moviecs.Any(e => e.Id == id);
        }
    }
}
