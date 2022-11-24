using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;

namespace ReservationWorkplace.Repositories.EquipmentRepository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ReservationDbContext _context;

        public EquipmentRepository(ReservationDbContext context)
        {
            _context = context;
        }



        public List<Equipment> EquipmentGetAll()
        {

            return _context.Equipments.ToList();
        }

        public Equipment EquipmentGetById(int id)
        {
            return _context.Equipments.FirstOrDefault(e => e.Id == id);
        }

        public void CreateEquipment(Equipment equipment)
        {

            _context.Equipments.Add(equipment);
            _context.SaveChanges();

        }

        public void UpdateEquipment(Equipment equipment)
        {
            _context.Equipments.Update(equipment);
            _context.SaveChanges();

        }
        public void DeleteEquipment(Equipment equipment)
        {
            _context.Equipments.Remove(equipment);

            _context.SaveChanges();

        }
    }
}
