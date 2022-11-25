using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Models;
using ReservationWorkplace.Services.WorkplaceService;

namespace ReservationWorkplace.Controllers
{
    public class WorkplaceController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkplaceService _workplaceService;
        public WorkplaceController(IWorkplaceService workplaceService, IMapper mapper)
        {
            _workplaceService = workplaceService;
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
    }
}


