using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClinicaApp.Data;
using ClinicaApp.Models;

namespace ClinicaApp.Controllers
{
    public class HistorialMedicoesController : Controller
    {
        private readonly ClinicaDbContext _context;

        public HistorialMedicoesController(ClinicaDbContext context)
        {
            _context = context;
        }

        // GET: HistorialMedicoes
        public async Task<IActionResult> Index()
        {
            var clinicaDbContext = _context.HistorialesMedicos.Include(h => h.Paciente);
            return View(await clinicaDbContext.ToListAsync());
        }

        // GET: HistorialMedicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialesMedicos
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Create
        public IActionResult Create()
        {
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Apellido");
            return View();
        }

        // POST: HistorialMedicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Diagnostico,Tratamiento,PacienteId")] HistorialMedico historialMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Apellido", historialMedico.PacienteId);
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialesMedicos.FindAsync(id);
            if (historialMedico == null)
            {
                return NotFound();
            }
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Apellido", historialMedico.PacienteId);
            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Diagnostico,Tratamiento,PacienteId")] HistorialMedico historialMedico)
        {
            if (id != historialMedico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialMedicoExists(historialMedico.Id))
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
            ViewData["PacienteId"] = new SelectList(_context.Pacientes, "Id", "Apellido", historialMedico.PacienteId);
            return View(historialMedico);
        }

        // GET: HistorialMedicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialMedico = await _context.HistorialesMedicos
                .Include(h => h.Paciente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historialMedico == null)
            {
                return NotFound();
            }

            return View(historialMedico);
        }

        // POST: HistorialMedicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialMedico = await _context.HistorialesMedicos.FindAsync(id);
            if (historialMedico != null)
            {
                _context.HistorialesMedicos.Remove(historialMedico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialMedicoExists(int id)
        {
            return _context.HistorialesMedicos.Any(e => e.Id == id);
        }
    }
}
