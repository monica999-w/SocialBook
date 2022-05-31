#nullable disable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialBook.Data;
using SocialBook.Models;
using SocialBook.Repositories.Interfaces;
using SocialBook.Service;

namespace SocialBook
{
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        private PostImageProcessorService _postImageProcessorService;

        public PostsController(IPostRepository postRepository, PostImageProcessorService postImageProcessorService)
        {
            _postRepository = postRepository;
            _postImageProcessorService = postImageProcessorService;
        }


        // GET: Posts
       [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _postRepository.GetList());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postRepository.GetById((int) id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageFile,Content,Status,CreatedAt,ModifiedAt")] Post post)
        {
            if (ModelState.IsValid)
            {
                await _postImageProcessorService.CopyFile(post);

                _postRepository.Add(post);
                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postRepository.GetById((int) id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,ImageFile,Content,Status,CreatedAt,ModifiedAt")]
            Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _postImageProcessorService.CopyFile(post);
                    _postRepository.Modify(post);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_postRepository.Exists(post.Id))
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

            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _postRepository.GetById((int) id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _postRepository.GetById(id);

            if (post == null)
            {
                return NotFound();
            }

            _postRepository.Delete(post);
            return RedirectToAction(nameof(Index));
        }
        
    }
}