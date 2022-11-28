using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.EmployeeService;

namespace ReservationWorkplace.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private IValidator<EmployeeViewModel> _validator;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IValidator<EmployeeViewModel> validator)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var dto = _employeeService.GetAllEmployee();
            var viewModel = _mapper.Map<List<EmployeeViewModel>>(dto);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Create", model);
            }

            var dto = _mapper.Map<EmployeeDto>(model);
            _employeeService.CreateEmployee(dto);

            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = _employeeService.GetByIdEmployee(id);
            var viewModel = _mapper.Map<EmployeeViewModel>(dto);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Edit", model);
            }

            var dto = _mapper.Map<EmployeeDto>(model);
            _employeeService.UpdateEmployee(dto);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        
    }
}
