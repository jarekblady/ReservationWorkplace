using ReservationWorkplace.Models;

namespace ReservationWorkplace.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeViewModel> GetAllEmployee();
        EmployeeViewModel GetByIdEmployee(int id);
        void CreateEmployee(EmployeeViewModel model);
        void UpdateEmployee(EmployeeViewModel model);
        void DeleteEmployee(int id);
    }
}
