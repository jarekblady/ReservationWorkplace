using AutoMapper;
using ReservationWorkplace.Entities;
using ReservationWorkplace.Models;
using ReservationWorkplace.Repositories.EmployeeRepository;

namespace ReservationWorkplace.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
    

        public List<EmployeeViewModel> GetAllEmployee()
        {
            var employees = _employeeRepository.EmployeeGetAll();
            var result = _mapper.Map<List<EmployeeViewModel>>(employees);
            return result;
        }

        public EmployeeViewModel GetByIdEmployee(int id)
        {
            var employee = _employeeRepository.EmployeeGetById(id);
            var result = _mapper.Map<EmployeeViewModel>(employee);
            return result;
        }


        public void CreateEmployee(EmployeeViewModel model)
        {
            var employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            _employeeRepository.CreateEmployee(employee);
        }

        public void UpdateEmployee(EmployeeViewModel model)
        {
            var employee = new Employee()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
            };
            _employeeRepository.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employeeRepository.EmployeeGetById(id);
            _employeeRepository.DeleteEmployee(employee);
        }


    }
}
