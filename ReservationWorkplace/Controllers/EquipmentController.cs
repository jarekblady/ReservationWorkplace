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
        private readonly IEquipmentService _equipmentService;
        private IValidator<EquipmentViewModel> _validator;
        public EquipmentController(IEquipmentService equipmentService, IValidator<EquipmentViewModel> validator)
        {
            _equipmentService = equipmentService;
            _validator = validator;
        }
        public IActionResult Index()
        {
            var viewModel = new EquipmentViewModel();

            viewModel.Equipments = _equipmentService.GetAllEquipment();

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

            var dto = new EquipmentDto
            {
                Type = model.Equipment.Type,
            };

            _equipmentService.CreateEquipment(dto);

            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = new EquipmentViewModel();
            viewModel.Equipment = _equipmentService.GetByIdEquipment(id);

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

            var dto = new EquipmentDto
            {
                Id = model.Equipment.Id,
                Type = model.Equipment.Type,
            };
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
