#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;

namespace SocialBook
{
    public class ReactionsController : Controller
    {
        private readonly IReactionRepository _reactionsRepository;

        public ReactionsController(IReactionRepository reactionsRepository)
        {
            _reactionsRepository = reactionsRepository;
        }

        // GET: Reactions
        public async Task<IActionResult> Index()
        {
            return View(_reactionsRepository.GetList());
        }

        // GET: Reactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reaction = await _reactionsRepository.GetById((int)id);
            if (reaction == null)
            {
                return NotFound();
            }

            return View(reaction);
        }

        // GET: Reactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Status,CreatedAt,ModifiedAt")] Reaction reaction)
        {
            if (ModelState.IsValid)
            {
                _reactionsRepository.Save(reaction);
                return RedirectToAction(nameof(Index));
            }
            return View(reaction);
        }

        // GET: Reactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reaction = await _reactionsRepository.GetById((int)id);
            if (reaction == null)
            {
                return NotFound();
            }
            return View(reaction);
        }

        // POST: Reactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Status,CreatedAt,ModifiedAt")] Reaction reaction)
        {
            if (id != reaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reactionsRepository.Update(reaction);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_reactionsRepository.Exists(reaction.Id))
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
            return View(reaction);
        }

        // GET: Reactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reaction = await _reactionsRepository.GetById((int)id);
            if (reaction == null)
            {
                return NotFound();
            }

            return View(reaction);
        }

        // POST: Reactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reaction = await _reactionsRepository.GetById((int)id);
            if (reaction == null)
            {
                return NotFound();
            }
            _reactionsRepository.Delete(reaction);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
