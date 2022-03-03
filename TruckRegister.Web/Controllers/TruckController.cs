using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruckRegister.Application.Interfaces;
using TruckRegister.Application.ViewModels;
using TruckRegister.Domain.Enums;
using TruckRegister.Domain.Helper;
using TruckRegister.Repository.Data;

namespace TruckRegister.Web.Controllers
{
    public class TruckController : Controller
    {
        private readonly ITruckBll _truckBll;

        public TruckController(ITruckBll truckBll)
        {
            _truckBll = truckBll;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _truckBll.GetAllTrucksEnablesAsync(HttpContext.RequestAborted));
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            return View(await _truckBll.GetDetailsTruckEnableByIdAsync(id, HttpContext.RequestAborted));
        }

        public async Task<IActionResult> Create()
        {
            var fabricationYear = new List<int>();
            var modelYear = new List<int>();

            fabricationYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));

            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));
            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")) + 1);

            ViewData["FabricationYear"] = new SelectList(fabricationYear);
            ViewData["ModelYear"] = new SelectList(modelYear);
            ViewData["Models"] = GetModels();

            return View(new TruckViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TruckViewModel truck)
        {
            if (ModelState.IsValid)
            {
                await _truckBll.CreateTruckAsync(truck, HttpContext.RequestAborted);

                return RedirectToAction(nameof(Index));
            }

            ViewData["Models"] = GetModels(truck.Model);

            return View(truck);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var truck = await _truckBll.GetTruckEnableByIdAsync(id, HttpContext.RequestAborted);

            if (truck == null)
                return NotFound();            

            var fabricationYear = new List<int>();
            var modelYear = new List<int>();

            fabricationYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));

            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")));
            modelYear.Add(int.Parse(DateTime.Now.ToString("yyyy")) + 1);

            ViewData["FabricationYear"] = new SelectList(fabricationYear);
            ViewData["ModelYear"] = new SelectList(modelYear);

            ViewData["Models"] = GetModels(truck.Model);

            return View(truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TruckViewModel truck)
        {
            if (id != truck.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                await _truckBll.UpdateTruckAsync(id, truck, HttpContext.RequestAborted);

                return RedirectToAction(nameof(Index));
            }

            ViewData["Models"] = GetModels(truck.Model);

            return View(truck);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var truck = await _truckBll.GetDetailsTruckEnableByIdAsync(id, HttpContext.RequestAborted);

            if (truck == null)
                return NotFound();

            ViewBag.models = GetModels(truck.Model);

            return View(truck);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _truckBll.DeleteTruckAsync(id, HttpContext.RequestAborted);

            return RedirectToAction(nameof(Index));
        }        

        private List<SelectListItem> GetModels(string model = "")
        {
            var list = new List<SelectListItem>();            
            list.AddRange(Enum.GetValues(typeof(TruckModel)).Cast<TruckModel>().Select(x => new SelectListItem
            {
                Text = x.ToDescription(),
                Value = x.ToDescription(), //((int)x).ToString(),
                Selected = x.ToDescription() == model,
            }));

            return list;
        }
    }
}
