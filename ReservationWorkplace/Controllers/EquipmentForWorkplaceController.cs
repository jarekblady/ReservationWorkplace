using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.EquipmentForWorkplaceService;
using ReservationWorkplace.Services.EquipmentService;
using ReservationWorkplace.Services.WorkplaceService;

namespace ReservationWorkplace.Controllers
{
    public class EquipmentForWorkplaceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentForWorkplaceService _equipmentForWorkplaceService;
        private readonly IEquipmentService _equipmentService;
        private readonly IWorkplaceService _workplaceService;
        public EquipmentForWorkplaceController(IEquipmentForWorkplaceService equipmentForWorkplaceService, IEquipmentService equipmentService, IWorkplaceService workplaceService, IMapper mapper)
        {
            _equipmentForWorkplaceService = equipmentForWorkplaceService;
            _equipmentService = equipmentService;
            _workplaceService = workplaceService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var dto = _equipmentForWorkplaceService.GetAllEquipmentForWorkplace();
            var viewModel = _mapper.Map<List<EquipmentForWorkplaceViewModel>>(dto);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Equipments = new SelectList(_equipmentService.GetAllEquipment(), "Id", "Type");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "Floor");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentForWorkplaceViewModel model)
        {
            ViewBag.Equipments = new SelectList(_equipmentService.GetAllEquipment(), "Id", "Type");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "Floor");

            var dto = _mapper.Map<EquipmentForWorkplaceDto>(model);
            _equipmentForWorkplaceService.CreateEquipmentForWorkplace(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Equipments = new SelectList(_equipmentService.GetAllEquipment(), "Id", "Type");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "Floor");

            var dto = _equipmentForWorkplaceService.GetByIdEquipmentForWorkplace(id);
            var viewModel = _mapper.Map<EquipmentForWorkplaceViewModel>(dto);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentForWorkplaceViewModel model)
        {
            var dto = _mapper.Map<EquipmentForWorkplaceDto>(model);
            _equipmentForWorkplaceService.UpdateEquipmentForWorkplace(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _equipmentForWorkplaceService.DeleteEquipmentForWorkplace(id);
            return RedirectToAction("Index");
        }
    }
}

