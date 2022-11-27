using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.EquipmentService;
using ReservationWorkplace.Services.WorkplaceService;

namespace ReservationWorkplace.Controllers
{
    public class WorkplaceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkplaceService _workplaceService;
        private readonly IEquipmentService _equipmentService;
        public WorkplaceController(IWorkplaceService workplaceService, IEquipmentService equipmentService, IMapper mapper)
        {
            _workplaceService = workplaceService;
            _equipmentService = equipmentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var dto = _workplaceService.GetAllWorkplace();
            var viewModel = _mapper.Map<List<WorkplaceViewModel>>(dto);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkplaceViewModel model)
        {

            var dto = _mapper.Map<WorkplaceDto>(model);
            _workplaceService.CreateWorkplace(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dto = _workplaceService.GetByIdWorkplace(id);
            var viewModel = _mapper.Map<WorkplaceViewModel>(dto);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(WorkplaceViewModel model)
        {
            var dto = _mapper.Map<WorkplaceDto>(model);
            _workplaceService.UpdateWorkplace(dto);

            return RedirectToAction("Index");;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _workplaceService.DeleteWorkplace(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var dto = _workplaceService.GetAllEquipmentForWorkplaceId(id);
            var viewModel = _mapper.Map<List<EquipmentForWorkplaceViewModel>>(dto);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult AddEquipment()
        {
            ViewBag.Equipments = new SelectList(_equipmentService.GetAllEquipment(), "Id", "Type");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "WorkplaceName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEquipment(EquipmentForWorkplaceViewModel model)
        {
            ViewBag.Equipments = new SelectList(_equipmentService.GetAllEquipment(), "Id", "Type");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "WorkplaceName");

            var dto = _mapper.Map<EquipmentForWorkplaceDto>(model);
            _workplaceService.AddEquipmentForWorkplace(dto);

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditEquipment(int id)
        {
            ViewBag.Equipments = new SelectList(_equipmentService.GetAllEquipment(), "Id", "Type");
            ViewBag.Workplaces = new SelectList(_workplaceService.GetAllWorkplace(), "Id", "WorkplaceName");

            var dto = _workplaceService.GetByIdEquipmentForWorkplace(id);
            var viewModel = _mapper.Map<EquipmentForWorkplaceViewModel>(dto);

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditEquipment(EquipmentForWorkplaceViewModel model)
        {
            var dto = _mapper.Map<EquipmentForWorkplaceDto>(model);
            _workplaceService.UpdateEquipmentForWorkplace(dto);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEquipment(int id)
        {
            _workplaceService.DeleteEquipmentForWorkplace(id);
            return RedirectToAction("Index");
        }
    }
}


