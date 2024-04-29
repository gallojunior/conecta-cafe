using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConectaCafe.Data;
using ConectaCafe.Models;

namespace ConectaCafe.Controllers;

public class TagsController : Controller
{
    private readonly AppDbContext _context;

    public TagsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Tags
    public async Task<IActionResult> Index()
    {
        return View(await _context.Tags.ToListAsync());
    }

    // GET: Tags/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Tags == null)
        {
            return NotFound();
        }

        var tag = await _context.Tags
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tag == null)
        {
            return NotFound();
        }

        return View(tag);
    }

    // GET: Tags/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Tags/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome")] Tag tag)
    {
        if (ModelState.IsValid)
        {
            if (!TagExists(tag))
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();
                TempData["Success"] = $"Tag '{tag.Nome}' cadastrada com Sucesso!";
                return RedirectToAction(nameof(Index));
            }
            else
                ModelState.AddModelError(string.Empty, "Nome já cadastrado!");
        }
        return View(tag);
    }

    // GET: Tags/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Tags == null)
        {
            return NotFound();
        }

        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            return NotFound();
        }
        return View(tag);
    }

    // POST: Tags/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Tag tag)
    {
        if (id != tag.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tag);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagExists(tag))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["Success"] = $"Tag '{tag.Nome}' alterada com Sucesso!";
            return RedirectToAction(nameof(Index));
        }
        return View(tag);
    }

    // GET: Tags/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Tags == null)
        {
            return NotFound();
        }

        var tag = await _context.Tags
            .FirstOrDefaultAsync(m => m.Id == id);
        if (tag == null)
        {
            return NotFound();
        }

        return View(tag);
    }

    // POST: Tags/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Tags == null)
        {
            return Problem("Entity set 'AppDbContext.Tags'  is null.");
        }
        var tag = await _context.Tags.FindAsync(id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
        }

        await _context.SaveChangesAsync();
        TempData["Success"] = $"Tag '{tag.Nome}' excluída com Sucesso!";
        return RedirectToAction(nameof(Index));
    }

    private bool TagExists(Tag tag)
    {
        if (tag.Id == 0)
            return _context.Tags.Any(e => e.Nome == tag.Nome);
        else
            return _context.Tags.Any(e => e.Id == tag.Id);
    }
}