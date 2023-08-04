using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WK_Services.Application.Interfaces;
using WK_Services.Application.ViewModels.User;
using WK_Services.Domain.Models;
using WK_Services.Utility;

namespace WK_Services.Presentation.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class ContactsController : Controller
    {
        readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index(int clientId)
        {
            ViewBag.ClientId = clientId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoadData(int clientId)
        {
            try
            {    
                var result = await _contactService.GetContactVMDataTableVM(clientId);
                return Json(result);
            }
            catch (Exception ex)
            {

            }


            return Json(null);
        }

        public IActionResult Create(int clientId)
        {
            ViewBag.ClientId = clientId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactVM ContactVM, int clientId)
        {
            if (ModelState.IsValid)
            {


                var result = await _contactService.Create(ContactVM);
                if (result.IsSucceeded)
                {
                    return RedirectToAction("Index", new { clientId });
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(result.Error))
                        ModelState.AddModelError("", result.Error);
                }


            }
            ViewBag.ClientId = clientId;
            return View(ContactVM);
        }

        public async Task<IActionResult> Edit(int clientId, int id)
        {
            if (id <= 0)
                return NotFound();

            var contact = await _contactService.GetContactVM(id);

            if (contact is null)
                return NotFound();
            ViewBag.ClientId = clientId;
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactVM ContactVM, int id, int clientId)
        {
            if (ModelState.IsValid)
            {


                bool result = await _contactService.Update(ContactVM);
                if (result)
                {
                    return RedirectToAction("Index", new { clientId });
                }

            }
            ViewBag.ClientId = clientId;
            return View(ContactVM);
        }


    }
}