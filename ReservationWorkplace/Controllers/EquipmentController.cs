using AutoMapper;
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
        public EquipmentController(IEquipmentService equipmentService, IMapper mapper)
        {
            _equipmentService = equipmentService;
            _mapper = mapper;
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

