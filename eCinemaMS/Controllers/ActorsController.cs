using eCinemaMS.Data;
using eCinemaMS.Data.Servies;
using eCinemaMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCinemaMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActorsController : Controller
    {
        private readonly IActorsServices _service;

        public ActorsController(IActorsServices service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var AllActor = await _service.GetAllAsync();
            return View(AllActor);
        }

        //Get:Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("fullName,profilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Details/Id
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            var ActorDetail = await _service.GetByIdAsync(id);

            if (ActorDetail == null) return View("Error");
            return View(ActorDetail);
        }

        //Get: Actor/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var ActorDetail = await _service.GetByIdAsync(id);
            if (ActorDetail == null) return View("Error");
            return View(ActorDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fullName,profilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actor/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var ActorDetail = await _service.GetByIdAsync(id);
            if (ActorDetail == null) return View("Error");
            return View(ActorDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ActorDetail = await _service.GetByIdAsync(id);
            if (ActorDetail == null) return View("Error");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
