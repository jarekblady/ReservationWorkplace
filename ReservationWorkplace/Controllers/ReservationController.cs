using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.EmployeeService;
using ReservationWorkplace.Services.ReservationService;
using ReservationWorkplace.Services.WorkplaceService;

namespace ReservationWorkplace.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IReservationService _reservationService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;
        public ReservationController(IReservationService reservationService, IEmployeeService employeeService, IWorkplaceService workplaceService, IMapper mapper)
        {
            _reservationService = reservationService;
            _employeeService = employeeService;
            _workplaceService = workplaceService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var dto = _reservationService.GetAllReservation();
            var viewModel = _mapper.Map<List<ReservationViewModel>>(dto);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Employees = new SelectList(_employeeService.GetAllEmployee(), "Id", "FirstName");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "Floor");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            ViewBag.Employees = new SelectList(_employeeService.GetAllEmployee(), "Id", "FirstName");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "Floor");


            var dto = _mapper.Map<ReservationDto>(model);
            _reservationService.CreateReservation(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Employees = new SelectList(_employeeService.GetAllEmployee(), "Id", "FirstName");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "Floor");

            var dto = _reservationService.GetByIdReservation(id);
            var viewModel = _mapper.Map<ReservationViewModel>(dto);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ReservationViewModel model)
        {
            var dto = _mapper.Map<ReservationDto>(model);
            _reservationService.UpdateReservation(dto);

            return RedirectToAction("Index");
 
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _reservationService.DeleteReservation(id);
            return RedirectToAction("Index");
        }
    }
}

