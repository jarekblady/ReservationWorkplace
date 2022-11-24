using ReservationWorkplace.Entities;


namespace ReservationWorkplace.Repositories.WorkplaceRepository
{
    public interface IWorkplaceRepository
    {
        List<Workplace> WorkplaceGetAll();
        Workplace WorkplaceGetById(int id);
        void CreateWorkplace(Workplace workplace);
        void UpdateWorkplace(Workplace workplace);
        void DeleteWorkplace(Workplace workplace);
    }
}