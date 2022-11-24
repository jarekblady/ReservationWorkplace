using ReservationWorkplace.Entities;

namespace ReservationWorkplace.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> EmployeeGetAll();
        Employee EmployeeGetById(int id);
        void CreateEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
