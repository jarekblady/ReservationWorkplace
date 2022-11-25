using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.EmployeeService;

namespace ReservationWorkplace.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
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
            var dto = _mapper.Map<EmployeeDto>(model);
            _employeeService.CreateEmployee(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_employeeService.GetByIdEmployee(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
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
