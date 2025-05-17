using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenLenguajes.DA;
using ExamenLenguajes.Model;
using ExamenLenguajes.BL;

namespace ExamenLenguajes.UI.Controllers
{
    public class ApartamentosController : Controller
    {
        private readonly AppDbContext _context;

        public ApartamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Apartamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartamentos.ToListAsync());
        }

        // GET: Apartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamentos = await _context.Apartamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamentos == null)
            {
                return NotFound();
            }

            return View(apartamentos);
        }

        // GET: Apartamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,NumeroDePiso,Descripcion,PrecioPorMes,Estado")] Apartamentos apartamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartamentos);
        }

        // GET: Apartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamentos = await _context.Apartamentos.FindAsync(id);
            if (apartamentos == null)
            {
                return NotFound();
            }
            return View(apartamentos);
        }

        // POST: Apartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,NumeroDePiso,Descripcion,PrecioPorMes,Estado")] Apartamentos apartamentos)
        {
            if (id != apartamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentosExists(apartamentos.Id))
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
            return View(apartamentos);
        }

        // GET: Apartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamentos = await _context.Apartamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartamentos == null)
            {
                return NotFound();
            }

            return View(apartamentos);
        }

        // POST: Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartamentos = await _context.Apartamentos.FindAsync(id);
            if (apartamentos != null)
            {
                _context.Apartamentos.Remove(apartamentos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentosExists(int id)
        {
            return _context.Apartamentos.Any(e => e.Id == id);
        }

        // GET: Apartamentos
        public async Task<IActionResult> Filtrar(string? nombre)
        {
            var query = _context.Apartamentos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(a => a.Nombre.Contains(nombre));
            }

            var resultado = await _context.Apartamentos.FirstOrDefaultAsync(a => a.Nombre.Contains(nombre));
            return View(resultado); 
        }

        // GET: Apartamentos/Alquilar/5
        public async Task<IActionResult> Alquilar(int? id)
        {
            if (id == null)
                return NotFound();

            var apartamento = await _context.Apartamentos.FindAsync(id);
            if (apartamento == null || apartamento.Estado != Estado.Disponible)
                return NotFound();

            ViewBag.ApartamentoId = id;
            return View();
        }


        // POST: Apartamentos/Alquilar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alquilar(int id, Alquiler alquiler)
        {
            var apartamento = await _context.Apartamentos.FindAsync(id);
            if (apartamento == null || apartamento.Estado != Estado.Disponible)
                return NotFound();

           
            int deposito = (int)GestionAlquileres.CalcularMontoDeposito(apartamento.PrecioPorMes, alquiler.CantidadMeses);

            
            apartamento.Estado = Estado.Alquilado;
            apartamento.IdentificacionInquilino = alquiler.Identificacion;
            apartamento.NombreInquilino = alquiler.NombreInquilino;
            apartamento.FechaInicioAlquiler = alquiler.FechaInicio;
            apartamento.CantidadDeMesesAlquiler = alquiler.CantidadMeses;
            apartamento.DepositoDeGarantia = deposito;

            _context.Update(apartamento);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Devolver(int id)
        {
            var apartamento = await _context.Apartamentos.FindAsync(id);

            if (apartamento == null || apartamento.Estado != Estado.Alquilado)
                return NotFound();

            apartamento.Estado = Estado.Disponible;
            apartamento.IdentificacionInquilino = null;
            apartamento.NombreInquilino = null;
            apartamento.FechaInicioAlquiler = null;
            apartamento.CantidadDeMesesAlquiler = null;
            apartamento.DepositoDeGarantia = null;

            _context.Update(apartamento);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Apartamentos/Disponibles
        public async Task<IActionResult> Disponibles()
        {
            var disponibles = await _context.Apartamentos
                .Where(a => a.Estado == Estado.Disponible)
                .ToListAsync();
            return View("Index", disponibles); 
        }

        // GET: Apartamentos/Alquilados

        public async Task<IActionResult> Alquilados(string? inquilino)
        {
            var query = _context.Apartamentos
                .Where(a => a.Estado == Estado.Alquilado);

            if (!string.IsNullOrWhiteSpace(inquilino))
            {
                query = query.Where(a => a.NombreInquilino.Contains(inquilino));
            }

            var resultado = await query.ToListAsync();
            return View(resultado);
        }

        public async Task<IActionResult> DetalleAlquilados(int? id)
        {
            if (id == null)
                return NotFound();

            var apartamento = await _context.Apartamentos.FirstOrDefaultAsync(a => a.Id == id);
            if (apartamento == null)
                return NotFound();

            return View(apartamento);
        }



    }
}
