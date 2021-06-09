using BurgerAPp.Repository;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BurgerApp.Controllers
{
    public class BurgerController : Controller
    {
        private readonly ILogger<BurgerController> _logger;
        private IBurgerRepository _repository;
        public BurgerController(ILogger<BurgerController> logger, IBurgerRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        // GET: BurgerController
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetBurgersAsync());
        }

        // GET: BurgerController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            //Classique
            //return View(_repository.GetBurger(id));


            //Asynchrone
            if (id == null)
            {
                return NotFound();
            }

            var burger = await _repository.GetBurgerAsync((int)id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }

        // GET: BurgerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BurgerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Weight,BeefWeight,Id,Name,Price,Description")] Burger burger)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _repository.AddBurger(burger);
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return View();
            //} 
            //catch
            //{
            //    return View();
            //}

            //Asynchorne
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(burger);
                return RedirectToAction(nameof(Index));
            }
            return View(burger);
        }

        // GET: BurgerController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //Asynchrone
            if (id == null)
            {
                return NotFound();
            }

            var burger = await _repository.GetBurgerAsync((int)id);
            if (burger == null)
            {
                return NotFound();
            }
            return View(burger);
        }

        // POST: BurgerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Weight,BeefWeight,Id,Name,Price,Description")] Burger burger)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        _repository.EditBurger(id, burger);
            //        return RedirectToAction(nameof(Index));
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}

            //Asynchrone
            if (id != burger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(burger);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BurgerTrue(burger.Id))
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
            return View(burger);
        }

        private bool BurgerTrue(int id)
        {
            return _repository.GetBurgersAsync().Result.Any(e => e.Id == id);
        }

        // GET: BurgerController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var burger = await _repository.GetBurgerAsync((int)id);
            if (burger == null)
            {
                return NotFound();
            }

            return View(burger);
        }

        // POST: BurgerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
