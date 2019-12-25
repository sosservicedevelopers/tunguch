﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AisMKIT.Data;
using AisMKIT.Models;

namespace AisMKIT.Areas.Cinematography.Controllers
{
    [Area("Cinematography")]
    public class ListOfCinematographiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListOfCinematographiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cinematography/ListOfCinematographies
        public async Task<IActionResult> Index(int Id=0)
        {
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", Id);
            var applicationDbContext = _context.ListOfCinematography.Include(l => l.DictDistrict).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            if (Id != 0)
                applicationDbContext = _context.ListOfCinematography.Where(x => x.DictFinSourceId == Id & x.DeactiveDate == null).Include(l => l.DictFinSource).Include(l => l.DictLegalForm);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cinematography/ListOfCinematographies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematography = await _context.ListOfCinematography
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematography == null)
            {
                return NotFound();
            }

            return View(listOfCinematography);
        }

        // GET: Cinematography/ListOfCinematographies/Create
        public IActionResult Create()
        {
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus");
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus");
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus");
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus");
            ListOfCinematography model = new ListOfCinematography();
            model.CreateDate = DateTime.Now;
            model.NameKyrg = "NULL";
            return View(model);
        }

        // POST: Cinematography/ListOfCinematographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictFinSourceId,DictDistrictId,LegalAddress,FactDistrictId,LegalFactAddress,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate")] ListOfCinematography listOfCinematography)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listOfCinematography);
                await _context.SaveChangesAsync();
                HistorySaved(listOfCinematography);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfCinematography.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfCinematography.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfCinematography.DictLegalFormId);
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus", listOfCinematography.FactDistrictId);
            return View(listOfCinematography);
        }

        private void HistorySaved(ListOfCinematography listOfCinematography)
        {
            ListOfCinematographyHistory lh = new ListOfCinematographyHistory();
            lh.CreateDate = listOfCinematography.CreateDate;
            lh.DeactiveDate = listOfCinematography.DeactiveDate;
            lh.DictDistrictId = listOfCinematography.DictDistrictId;
            lh.DictFinSourceId = listOfCinematography.DictFinSourceId;
            lh.DictLegalFormId = listOfCinematography.DictLegalFormId;
            lh.FactDistrictId = listOfCinematography.FactDistrictId;
            lh.FirstNameDirector = listOfCinematography.FirstNameDirector;
            lh.INN = listOfCinematography.INN;
            lh.LastNameDirector = listOfCinematography.LastNameDirector;
            lh.LegalAddress = listOfCinematography.LegalAddress;
            lh.LegalFactAddress = listOfCinematography.LegalFactAddress;
            lh.ListOfCinematographyId = listOfCinematography.Id;
            lh.NameKyrg = listOfCinematography.NameKyrg;
            lh.NameRus = listOfCinematography.NameRus;
            lh.PatronicNameDirector = listOfCinematography.PatronicNameDirector;
            lh.RegistrationDate = listOfCinematography.RegistrationDate;
            lh.ReregistrationDate = listOfCinematography.ReregistrationDate;
            _context.ListOfCinematographyHistory.Add(lh);
            _context.SaveChanges();
        }

        // GET: Cinematography/ListOfCinematographies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematography = await _context.ListOfCinematography.FindAsync(id);
            if (listOfCinematography == null)
            {
                return NotFound();
            }
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfCinematography.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfCinematography.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfCinematography.DictLegalFormId);
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus", listOfCinematography.FactDistrictId);
            return View(listOfCinematography);
        }

        // POST: Cinematography/ListOfCinematographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameRus,NameKyrg,DictLegalFormId,INN,LastNameDirector,FirstNameDirector,PatronicNameDirector,DictFinSourceId,DictDistrictId,LegalAddress,FactDistrictId,LegalFactAddress,RegistrationDate,ReregistrationDate,DeactiveDate,CreateDate")] ListOfCinematography listOfCinematography,string SubmitButton="")
        {
            if (id != listOfCinematography.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listOfCinematography);
                    await _context.SaveChangesAsync();
                    if (SubmitButton == "Перерегистрировать") HistorySaved(listOfCinematography);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListOfCinematographyExists(listOfCinematography.Id))
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
            ViewData["DictDistrictId"] = new SelectList(_context.DictDistrict, "Id", "NameRus", listOfCinematography.DictDistrictId);
            ViewData["DictFinSourceId"] = new SelectList(_context.DictFinSource, "Id", "NameRus", listOfCinematography.DictFinSourceId);
            ViewData["DictLegalFormId"] = new SelectList(_context.DictLegalForm, "Id", "NameRus", listOfCinematography.DictLegalFormId);
            ViewData["FactDistrictId"] = new SelectList(_context.DictDistrict, "NameRus", "NameRus", listOfCinematography.FactDistrictId);
            return View(listOfCinematography);
        }

        // GET: Cinematography/ListOfCinematographies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listOfCinematography = await _context.ListOfCinematography
                .Include(l => l.DictDistrict)
                .Include(l => l.DictFinSource)
                .Include(l => l.DictLegalForm)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listOfCinematography == null)
            {
                return NotFound();
            }

            return View(listOfCinematography);
        }

        // POST: Cinematography/ListOfCinematographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listOfCinematography = await _context.ListOfCinematography.FindAsync(id);
            _context.ListOfCinematography.Remove(listOfCinematography);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListOfCinematographyExists(int id)
        {
            return _context.ListOfCinematography.Any(e => e.Id == id);
        }
    }
}