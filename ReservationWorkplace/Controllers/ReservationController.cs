﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IReservationService _reservationService;
        private readonly IEmployeeService _employeeService;
        private readonly IWorkplaceService _workplaceService;
        private IValidator<ReservationViewModel> _validator;
        public ReservationController(IReservationService reservationService, IEmployeeService employeeService, IWorkplaceService workplaceService, IMapper mapper, IValidator<ReservationViewModel> validator)
        {
            _reservationService = reservationService;
            _employeeService = employeeService;
            _workplaceService = workplaceService;
            _mapper = mapper;
            _validator = validator;
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
            ViewBag.Employees = new SelectList(_employeeService.GetAllEmployee(), "Id", "FullName");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "WorkplaceName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {
            ViewBag.Employees = new SelectList(_employeeService.GetAllEmployee(), "Id", "FullName");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "WorkplaceName");

            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Create", model);
            }

            var dto = _mapper.Map<ReservationDto>(model);
            _reservationService.CreateReservation(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Employees = new SelectList(_employeeService.GetAllEmployee(), "Id", "FullName");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "WorkplaceName");


            var dto = _reservationService.GetByIdReservation(id);
            var viewModel = _mapper.Map<ReservationViewModel>(dto);

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

