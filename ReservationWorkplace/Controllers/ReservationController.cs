using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
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
        private readonly IReservationService _reservationService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;

        private IValidator<ReservationViewModel> _validator;
        public ReservationController(IReservationService reservationService, IEmployeeService employeeService, IWorkplaceService workplaceService, IValidator<ReservationViewModel> validator)
        {
            _reservationService = reservationService;
            _workplaceService = workplaceService;
            _employeeService = employeeService;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var viewModel = new ReservationViewModel();
            viewModel.Reservations = _reservationService.GetAllReservation();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var employees = new EmployeeViewModel();
            employees.Employees = _employeeService.GetAllEmployee();
            var workplaces = new WorkplaceViewModel();
            workplaces.Workplaces = _workplaceService.GetAllWorkplace();
            ViewBag.Employees = new SelectList(employees.Employees, "Id", "FullName");
            ViewBag.Workplaces = new SelectList(workplaces.Workplaces, "Id", "WorkplaceName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            var employees = new EmployeeViewModel();
            employees.Employees = _employeeService.GetAllEmployee();
            var workplaces = new WorkplaceViewModel();
            workplaces.Workplaces = _workplaceService.GetAllWorkplace();
            ViewBag.Employees = new SelectList(employees.Employees, "Id", "FullName");
            ViewBag.Workplaces = new SelectList(workplaces.Workplaces, "Id", "WorkplaceName");

            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Create", model);
            }

            var dto = new ReservationDto()
            {
                TimeFrom = model.Reservation.TimeFrom,
                TimeTo = model.Reservation.TimeTo,
                EmployeeId = model.Reservation.EmployeeId,
                WorkplaceId = model.Reservation.WorkplaceId,
            };
            _reservationService.CreateReservation(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var employees = new EmployeeViewModel();
            employees.Employees = _employeeService.GetAllEmployee();
            var workplaces = new WorkplaceViewModel();
            workplaces.Workplaces = _workplaceService.GetAllWorkplace();
            ViewBag.Employees = new SelectList(employees.Employees, "Id", "FullName");
            ViewBag.Workplaces = new SelectList(workplaces.Workplaces, "Id", "WorkplaceName");

            var viewModel = new ReservationViewModel();
            viewModel.Reservation = _reservationService.GetByIdReservation(id);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ReservationViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Edit", model);
            }

            var dto = new ReservationDto()
            {
                Id = model.Reservation.Id,
                TimeFrom = model.Reservation.TimeFrom,
                TimeTo = model.Reservation.TimeTo,
                EmployeeId = model.Reservation.EmployeeId,
                WorkplaceId = model.Reservation.WorkplaceId,
            };
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

