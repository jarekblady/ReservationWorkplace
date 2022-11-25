using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Repositories.WorkplaceRepository
{
    public class WorkplaceRepository : IWorkplaceRepository
    {
        private readonly ReservationDbContext _context;

        public WorkplaceRepository(ReservationDbContext context)
        {
            _context = context;
        }



        public List<Workplace> WorkplaceGetAll()
        {

            return _context.Workplaces.ToList();
        }

        public Workplace WorkplaceGetById(int id)
        {
            return _context.Workplaces.FirstOrDefault(w => w.Id == id);
        }

        public void CreateWorkplace(Workplace workplace)
        {

            _context.Workplaces.Add(workplace);
            _context.SaveChanges();

        }

        public void UpdateWorkplace(Workplace workplace)
        {
            _context.Workplaces.Update(workplace);
            _context.SaveChanges();

        }
        public void DeleteWorkplace(Workplace workplace)
        {
            _context.Workplaces.Remove(workplace);

            _context.SaveChanges();

        }
    }
}