using AutoMapper;
using ReservationWorkplace.DataTransferObjects;
using ReservationWorkplace.Entities;
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


        public List<WorkplaceDto> GetAllWorkplace()
        {
            var workplaces = _workplaceRepository.WorkplaceGetAll();
            var result = _mapper.Map<List<WorkplaceDto>>(workplaces);
            return result;
        }

        public WorkplaceDto GetByIdWorkplace(int id)
        {
            var workplace = _workplaceRepository.WorkplaceGetById(id);
            var result = _mapper.Map<WorkplaceDto>(workplace);
            return result;
        }


        public void CreateWorkplace(WorkplaceDto dto)
        {
            var workplace = new Workplace()
            {            
                Floor = dto.Floor,
                Room = dto.Room,
                Table = dto.Table,
            };
            _workplaceRepository.CreateWorkplace(workplace);
        }

        public void UpdateWorkplace(WorkplaceDto dto)
        {
            var workplace = new Workplace()
            {
                Id = dto.Id,
                Floor = dto.Floor,
                Room = dto.Room,
                Table = dto.Table,
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
