using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WK_Services.Application.Interfaces;
using WK_Services.Application.ViewModels.User;
using WK_Services.Utility;

namespace WK_Services.Presentation.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ClientsController : Controller
    {
        readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadData()
        {
            try
            {
                var result = await _clientService.GetClientVMDataTableVM();
                return Json(result);
            }
            catch (Exception ex)
            {

            }
      
             
            return Json(null);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientVM ClientVM)
        {
            if (ModelState.IsValid)
            {


                bool result = await _clientService.Create(ClientVM);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(ClientVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return NotFound();

            var client = await _clientService.GetClientVM(id);

            if (client is null)
                return NotFound();

            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientVM ClientVM, int id)
        {
            if (ModelState.IsValid)
            {


                bool result = await _clientService.Update(ClientVM);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(ClientVM);
        }


    }
}