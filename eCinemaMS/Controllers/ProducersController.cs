using eCinemaMS.Data;
using eCinemaMS.Data.Servies;
using eCinemaMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCinemaMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProducersController : Controller
    {
        private readonly IProducersServices _service;
        public ProducersController(IProducersServices service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducers = await _service.GetAllAsync();
            return View(allProducers);
        }

        //Get:Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("fullName,profilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        //Get: Details/Id
        public async Task<IActionResult> Detail(int id)
        {
            var ProducerDetail = await _service.GetByIdAsync(id);

            if (ProducerDetail == null) return View("Empty");
            return View(ProducerDetail);
        }

        //Get: Producers/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var ProducerDetail = await _service.GetByIdAsync(id);
            if (ProducerDetail == null) return View("Error");
            return View(ProducerDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fullName,profilePictureUrl,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            await _service.UpdateAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //Get: Producer/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var ProducerDetail = await _service.GetByIdAsync(id);
            if (ProducerDetail == null) return View("Error");
            return View(ProducerDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProducerDetail = await _service.GetByIdAsync(id);
            if (ProducerDetail == null) return View("Error");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
