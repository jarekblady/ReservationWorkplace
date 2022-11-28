using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.EquipmentService;

namespace ReservationWorkplace.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentService _equipmentService;
        private IValidator<EquipmentViewModel> _validator;
        public EquipmentController(IEquipmentService equipmentService, IMapper mapper, IValidator<EquipmentViewModel> validator)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var dto = _equipmentService.GetAllEquipment();
            var viewModel = _mapper.Map<List<EquipmentViewModel>>(dto);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Create", model);
            }

            var dto = _mapper.Map<EquipmentDto>(model);
            _equipmentService.CreateEquipment(dto);

            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = _equipmentService.GetByIdEquipment(id);
            var viewModel = _mapper.Map<EquipmentViewModel>(dto);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentViewModel model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return View("Edit", model);
            }

            var dto = _mapper.Map<EquipmentDto>(model);
            _equipmentService.UpdateEquipment(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _equipmentService.DeleteEquipment(id);
            return RedirectToAction("Index");
        }
    }
}

