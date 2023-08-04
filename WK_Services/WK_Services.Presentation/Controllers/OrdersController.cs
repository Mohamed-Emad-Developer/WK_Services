using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WK_Services.Application.Interfaces;
using WK_Services.Application.Services;
using WK_Services.Application.ViewModels;
using WK_Services.Domain.Models.User;
using WK_Services.Utility;

namespace WK_Services.Presentation.Controllers
{
    [Authorize(Roles = $"{Roles.Admin},{Roles.Contact}")]
    public class OrdersController : Controller
    {
        readonly IOrderService _orderService;
        readonly IServiceService _serviceService;
        readonly IContactService _contactService;
        readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(IOrderService orderService, IServiceService serviceService, UserManager<ApplicationUser> userManager, IContactService contactService)
        {
            _orderService = orderService;
            _serviceService = serviceService;
            _userManager = userManager;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["ServicesList"] = await _serviceService.GetSelectList();
            return View();
        }

        [Authorize(Roles = Roles.Contact)]
        [HttpPost]
        public async Task<IActionResult> LoadClientOrders(OrderFilter filter)
        {
            try
            {
                var contactUserId = _userManager.GetUserId(User);
                var clientData = await _contactService.GetClientIdByContactUserId(contactUserId);
                
                var result = await _orderService.GetOrderVMDataTableVM(filter, clientData.Id);
                return Json(result);
            }
            catch (Exception ex)
            {

            }


            return Json(null);
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpPost]

        public async Task<IActionResult> LoadAllOrders(OrderFilter filter)
        {
            try
            {
                var result = await _orderService.GetOrderVMDataTableVM(filter);

                return Json(result);
            }
            catch (Exception ex)
            {

            }


            return Json(null);
        }
        [Authorize(Roles = Roles.Contact)]
        public async Task<IActionResult> Create()
        {
            ViewData["ServicesList"] = await _serviceService.GetSelectList();
            return View();
        }

        [Authorize(Roles = Roles.Contact)]
        [HttpPost]
        public async Task<IActionResult> Create(OrderVM order)
        {
            if (ModelState.IsValid)
            {
                var contactUserId = _userManager.GetUserId(User);
                var result = await _orderService.Create(order, contactUserId);
                if (result.IsSucceeded)
                {
                    return Json(new { succeeded = result.IsSucceeded, order = result.OrderNumber });
                }

            }

            return Json(new { succeeded = false });
        }



    }
}