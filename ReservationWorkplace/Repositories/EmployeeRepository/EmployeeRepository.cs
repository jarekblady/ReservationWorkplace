using Microsoft.EntityFrameworkCore;
using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ReservationDbContext _context;

        public EmployeeRepository(ReservationDbContext context)
        {
            _context = context;
        }

        public List<Employee> EmployeeGetAll()
        {

            return _context.Employees.Include(r => r.Reservations).ToList();
        }

        public Employee EmployeeGetById(int id)
        {
            return _context.Employees.Include(r => r.Reservations).FirstOrDefault(e => e.Id == id);
        }

        public void CreateEmployee(Employee employee)
        {

            _context.Employees.Add(employee);
            _context.SaveChanges();

        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();

        }
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);

            _context.SaveChanges();

        }
    }
}
