using ReservationWorkplace.DataTransferObjects;

namespace ReservationWorkplace.Services.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployee();
        EmployeeDto GetByIdEmployee(int id);
        void CreateEmployee(EmployeeDto dto);
        void UpdateEmployee(EmployeeDto dto);
        void DeleteEmployee(int id);
    }
}
