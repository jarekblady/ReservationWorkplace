using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;
using ReservationWorkplace.Repositories.WorkplaceRepository;

namespace ReservationWorkplace.Services.WorkplaceService
{
    public class WorkplaceService : IWorkplaceService
    {

           
        private readonly IWorkplaceRepository _workplaceRepository;
        private readonly IMapper _mapper;

        public WorkplaceService(IWorkplaceRepository workplaceRepository, IMapper mapper)
        {
            _workplaceRepository = workplaceRepository;
            _mapper = mapper;
        }


        public List<WorkplaceViewModel> GetAllWorkplace()
        {
            var workplaces = _workplaceRepository.WorkplaceGetAll();
            var result = _mapper.Map<List<WorkplaceViewModel>>(workplaces);
            return result;
        }

        public WorkplaceViewModel GetByIdWorkplace(int id)
        {
            var workplace = _workplaceRepository.WorkplaceGetById(id);
            var result = _mapper.Map<WorkplaceViewModel>(workplace);
            return result;
        }


        public void CreateWorkplace(WorkplaceViewModel model)
        {
            var workplace = new Workplace()
            {
                Floor = model.Floor,
                Room = model.Room,
                Table = model.Table,
            };
            _workplaceRepository.CreateWorkplace(workplace);
        }

        public void UpdateWorkplace(WorkplaceViewModel model)
        {
            var workplace = new Workplace()
            {
                Floor = model.Floor,
                Room = model.Room,
                Table = model.Table,
            };
            _workplaceRepository.UpdateWorkplace(workplace);
        }

        public void DeleteWorkplace(int id)
        {
            var workplace = _workplaceRepository.WorkplaceGetById(id);
            _workplaceRepository.DeleteWorkplace(workplace);
        }

    }
}
