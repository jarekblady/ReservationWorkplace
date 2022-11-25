using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Repositories.EquipmentForWorkplaceRepository
{
    public class EquipmentForWorkplaceRepository : IEquipmentForWorkplaceRepository
    {
        private readonly ReservationDbContext _context;

        public EquipmentForWorkplaceRepository(ReservationDbContext context)
        {
            _context = context;
        }



        public List<EquipmentForWorkplace> EquipmentForWorkplaceGetAll()
        {

            return _context.EquipmentForWorkplaces.ToList();
        }

        public EquipmentForWorkplace EquipmentForWorkplaceGetById(int id)
        {
            return _context.EquipmentForWorkplaces.FirstOrDefault(r => r.Id == id);
        }

        public void CreateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {

            _context.EquipmentForWorkplaces.Add(equipmentForWorkplace);
            _context.SaveChanges();

        }

        public void UpdateEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            _context.EquipmentForWorkplaces.Update(equipmentForWorkplace);
            _context.SaveChanges();

        }
        public void DeleteEquipmentForWorkplace(EquipmentForWorkplace equipmentForWorkplace)
        {
            _context.EquipmentForWorkplaces.Remove(equipmentForWorkplace);

            _context.SaveChanges();

        }
    }
}
