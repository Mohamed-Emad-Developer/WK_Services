using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WK_Services.Application.Interfaces;
using WK_Services.Domain.Models;
using WK_Services.Utility;

namespace WK_Services.Presentation.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ServicesController : Controller
    {
        readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _serviceService.GetAll();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            if (ModelState.IsValid)
            {
                var nameExist = await _serviceService.CheckNameExist(service.Name);
                if (nameExist)
                {
                    ModelState.AddModelError("Name", "This name is already exist.");
                }
                else
                {

                    bool result = await _serviceService.Create(service);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(service);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return NotFound();

            var service = await _serviceService.Get(id);

            if (service is null)
                return NotFound();

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Service service, int id)
        {
            if (ModelState.IsValid)
            {
                var nameExist = await _serviceService.CheckNameExist(service.Name, service.Id);
                if (nameExist)
                {
                    ModelState.AddModelError("Name", "This name is already exist.");
                }
                else
                {
                    bool result = await _serviceService.Update(service);
                    if (result)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(service);
        }


    }
}